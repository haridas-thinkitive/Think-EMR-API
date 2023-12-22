using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Data;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Models.Authentication.CustomData;
using ThinkEMR_Care.DataAccess.Models.Authentication.Login;
using ThinkEMR_Care.DataAccess.Models.Authentication.SignUp;
using ThinkEMR_Care.DataAccess.Models.EmailConfig;

namespace ThinkEMR_Care.Core.Services
{
    public class UserManagementService : IUserManagement
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSMTP _email;
        private readonly ApplicationDbContext _context;

        public UserManagementService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IEmailSMTP email,ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _email = email;

        }
        /// <summary>
        /// User Registration
        /// </summary>
        /// <param name="registerUser"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        public async Task<int> RegisterUser(RegisterUser registerUser, string Role)
        {
            try
            {
                int Result = 0;
                var userExist = await _userManager.FindByNameAsync(registerUser.Email);
                if (userExist != null)
                {
                    return Result;
                }
                // Convert the base64-encoded image to a byte array
                byte[]? profileImageSave = null;
                if (!string.IsNullOrEmpty(registerUser.ProfileImage))
                {
                    try
                    {
                        // Check if the base64 string contains a prefix
                        var base64Data = registerUser.ProfileImage.Contains(',')
                            ? registerUser.ProfileImage.Split(',')[1]
                            : registerUser.ProfileImage;

                        profileImageSave = Convert.FromBase64String(base64Data);
                    }
                    catch (Exception)
                    {
                        return Result;
                    }
                }
                ApplicationUser user = new ApplicationUser
                {
                    UserName = registerUser.UserName,
                    Email = registerUser.Email,
                    PhoneNumber = registerUser.ContactNumber,
                    FirstName = registerUser.FirstName,
                    LastName = registerUser.LastName,
                    IsDeleted = registerUser.IsDeleted,
                    Status = registerUser.Status,
                    ProfileImage = profileImageSave,
                    Role = registerUser.Role,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                if (await _roleManager.RoleExistsAsync(Role))
                {
                    var result = await _userManager.CreateAsync(user, registerUser.Password);
                    if (result.Succeeded)
                    {
                        // Add Role to the User
                        await _userManager.AddToRoleAsync(user, Role);
                        Result = 1;
                    }
                    else
                    {
                        return Result;
                    }
                }
                else
                {
                    return Result;
                }
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// User Loing
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public  async Task<ApiResponse<string>> LoginUser(LoginModel loginModel)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(loginModel.UserName);
                if (user == null || user.UserName != loginModel.UserName || !await _userManager.CheckPasswordAsync(user, loginModel.Password))
                {
                    return new ApiResponse<string>
                    {
                        IsSuccess = false, 
                        StatusCode = 500, 
                        Message = "Incorrect UserName And Password", 
                        CurrentUserNmae = "Not Found Any User",
                        Response = "Verify UserName And Password" };
                    }
                else
                {
                    await UpdateLastLoginAsync(user);

                    var authClaims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        };
                        var userRoles = await _userManager.GetRolesAsync(user);
                        foreach (var role in userRoles)
                        {
                            authClaims.Add(new Claim(ClaimTypes.Role, role));
                        }
                        var jwtToken = GetJwtToken(authClaims);
                        return new ApiResponse<string> { 
                            IsSuccess = true,
                            StatusCode = 200, 
                            Response = jwtToken, 
                            CurrentUserNmae = user.UserName, 
                            Message = "User Logged-In Successfully" 
                        };
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task UpdateLastLoginAsync(ApplicationUser user)
        {
            user.LastLogin = DateTime.Now;
            await _userManager.UpdateAsync(user);
        }

        private string GetJwtToken(List<Claim> authClaims)
        {
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: authClaims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<int> SendNotificationToUser(string Touser, string FromUser)
        {
            try
            {
                var result = 0;
                var Fromuser = await _userManager.FindByNameAsync(FromUser);
                var user = await _userManager.FindByNameAsync(Touser);
                if (user != null && Fromuser != null)
                {
                    var message = new Message(new string[] { user.Email }, $"Receive Message From  {Fromuser.FirstName} {Fromuser.LastName}", $"Login The Application and check {user.FirstName}..!");

                    await _email.SendEmail(message);

                    var notification = new Notification
                    {
                        UserId = user.Id,
                        Message = $"Receive Notification From {Fromuser.FirstName} {Fromuser.LastName}",
                        Timestamp = DateTime.Now,
                        IsRead = false
                    };

                    await _context.notifications.AddAsync(notification);
                    await _context.SaveChangesAsync();
                   return result = 1;

                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
