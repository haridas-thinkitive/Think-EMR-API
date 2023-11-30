using Microsoft.AspNetCore.Identity;
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
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Models.Authentication.CustomData;
using ThinkEMR_Care.DataAccess.Models.Authentication.Login;
using ThinkEMR_Care.DataAccess.Models.Authentication.SignUp;

namespace ThinkEMR_Care.Core.Services
{
    public class UserManagementService : IUserManagement
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSMTP _email;

        public UserManagementService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IEmailSMTP email)
        {
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
        public async Task<ApiResponse<string>> RegisterUser(RegisterUser registerUser, string Role)
        {
           try
            {
                var userExist = await _userManager.FindByNameAsync(registerUser.Email);
                if (userExist != null)
                {
                    return new ApiResponse<string> { IsSuccess = false, StatusCode = 403, Message = "User Already Exist" };
                }

                ApplicationUser user = new ApplicationUser
                {
                    UserName = registerUser.UserName,
                    Email = registerUser.Email,
                    SecurityStamp = Guid.NewGuid().ToString()
                    

                };

                if (await _roleManager.RoleExistsAsync(Role))
                {
                    var result = await _userManager.CreateAsync(user, registerUser.Password);
                    if (!result.Succeeded)
                    {
                        return new ApiResponse<string> { IsSuccess = false, StatusCode = 500, Message = "User failed To Create" };
                    }
                    await _userManager.AddToRoleAsync(user, Role);
                    return new ApiResponse<string> { IsSuccess = true, StatusCode = 200, Message = "User Created Successfully" };
                }
                else
                {
                    return new ApiResponse<string> { IsSuccess = false, StatusCode = 500, Message = "User Role Doesnot Exit.." };

                }
           }catch(Exception ex)
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
                if (user == null || (user.UserName != loginModel.UserName || !await _userManager.CheckPasswordAsync(user, loginModel.Password)))
                {
                    return new ApiResponse<string> { IsSuccess = false, StatusCode = 500, Message = "Incorrect UserName And Password" };
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
                        return new ApiResponse<string> { IsSuccess = true, StatusCode = 200, Response = jwtToken, CurrentUserNmae = user.UserName };
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

    }
}
