using Azure;
using Azure.Messaging;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using NETCore.MailKit.Core;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using ThinkEMR_Care.DataAccess.Data;
using ThinkEMR_Care.DataAccess.Models.Authentication.Login;
using ThinkEMR_Care.DataAccess.Models.Authentication.SignUp;
using ThinkEMR_Care.DataAccess.Models.EmailConfig;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.DataAccess.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEmail _email;

        public AuthenticationRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IEmail email)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _email = email;
        }

        public async Task<string> RegisterNewUser(RegisterUser registerUser, string role)
        {
            var IfExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (IfExist != null)
            {
                if (IfExist != null)
                {
                    return "User Already Exist";
                }
            }
            IdentityUser user = new()
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (!result.Succeeded)
                {
                    return "User Failed To Created";
                }
                //var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var ConformationLink = Url.Action(nameof(ConformUserDB), "Authentication", new { token, email = user.Email }, Request.Scheme);
                //var message = new Message(new string[] { user.Email!, "Conformation email link",ConformationLink! });
                //await _email.SendEmail(message);
                await _userManager.AddToRoleAsync(user, role);
                return "User Created Successfully";
            }
            else
            {
                return "This Role Dosen't Exist";
            }
        }

        public async Task<string> LoginUser(LoginModel loginModel)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(loginModel.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
                {
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
                    return jwtToken.ToString();
                }
                return "Invalid User";
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public async Task<string> ForgotPassword(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);


            }
            return null;
        }


        public async Task<string> ConformEmail()
        {
            var message = new Message(new string[] { "dhulgandeharidas83@gmail.com" }, "Text", "<h1>Test mail</h1>");
            await _email.SendEmail(message);
            return "Email Send Successfully";

        }

        public async Task<string> ConformUserDB(string email, string token)
        {
            var user = await _userManager.FindByIdAsync(email);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return "Email Varified Successfully";
                }
            }
            return "User Dosenot Exit";
        }

        public async Task<string> ResetPassword(string email)
        {
            var user = await _userManager.FindByIdAsync(email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                //var ConformationLink = Url.Action(nameof(ResetPassword), "Authentication", new { token, email = user.Email }, Request.Scheme);
                //var ForgotPasswordLink = new Message(new string[] { user.Email!, "Forgot Password link", ConformationLink! });
                //await _email.SendEmail(message);
                return "Forgot Password Email Send Successfully";
            }
            return "Failed To Reset Password Please try again";
        }

        public async Task<string> ResetPassword(string Token, string email)
        {
            var model = new ResetPassword { Token = Token, Email = email };

            var response = new
            {
                Message = "Password reset successful",
                ResetPasswordModel = model
            };
            var jsonString = JsonConvert.SerializeObject(response);

            return jsonString;

        }
    }
}
