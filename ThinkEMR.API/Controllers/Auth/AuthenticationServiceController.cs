using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using SmtpServer.Text;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Models.Authentication.Login;
using ThinkEMR_Care.DataAccess.Models.Authentication.SignUp;
using ThinkEMR_Care.DataAccess.Models.EmailConfig;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationServiceController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSMTP _email;

        public AuthenticationServiceController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IEmailSMTP email)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _email = email;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string Role)
        {
            // Check if User Exists
            var userExist = await _userManager.FindByNameAsync(registerUser.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Responce { status = "Error", Message = "User Already Exists" });
            }

            // Add the user to the database
            IdentityUser user = new IdentityUser
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            if (await _roleManager.RoleExistsAsync(Role))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (result.Succeeded)
                {
                    // Add Role to the User
                    await _userManager.AddToRoleAsync(user, Role);
                    return StatusCode(StatusCodes.Status200OK, new Responce { status = "Success", Message = "User Created Successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Responce { status = "Error", Message = "User Failed To Create" });
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responce { status = "Error", Message = "This Role Does Not Exist" });
            }
        }

        [HttpGet("Test-Email")]
        public async Task<IActionResult> TestMail()
        {
            var message = new Message(new string[] { "dhulgandeharidas83@gmail.com" }, "Text", "<h1>Test mail</h1>");
            await _email.SendEmail(message);
            return StatusCode(StatusCodes.Status403Forbidden, new Responce { status = "Success", Message = "Test Mail Send Successfully" });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
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
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                        expiration = jwtToken.ValidTo
                    });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private JwtSecurityToken GetJwtToken(List<Claim> authClaims)
        {
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: authClaims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
            );
            return token;
        }

        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var forgotPasswordLink = Url.Action(nameof(ResetPassword), "Authentication", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(new string[] { user.Email! }, "Forgot Password link", forgotPasswordLink!);
                await _email.SendEmail(message);
                return StatusCode(StatusCodes.Status200OK, new Responce { status = "Success", Message = $"Password changes request is send on email{user.Email}" });
            }
            return StatusCode(StatusCodes.Status200OK, new Responce { status = "Error", Message = "Failed To send link.. Please try again" });

        }

        [HttpGet("ResetPassword")]
        public async Task<IActionResult> Resetpassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };
            return Ok(new
            {
                model
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Reset-Password")]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user != null)
            {
                var ResetPasswordResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
                if (!ResetPasswordResult.Succeeded)
                {
                    foreach (var error in ResetPasswordResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return Ok(ModelState);
                }
                return StatusCode(StatusCodes.Status200OK, new Responce { status = "Success", Message = "Password Change Successfully" });

            }
            return StatusCode(StatusCodes.Status400BadRequest, new Responce { status = "Error", Message = "Somethis is missing...!" });

        }

    }

}

