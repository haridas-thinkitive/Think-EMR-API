using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
using ThinkEMR_Care.DataAccess.Models.Authentication.CustomData;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSMTP _email;

        public AuthenticationServiceController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IEmailSMTP email)
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
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string Role)
        {
           try
            {
                var userExist = await _userManager.FindByNameAsync(registerUser.Email);
                if (userExist != null)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, new Responce { status = "Error", Message = "User Already Exists" });
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
                        return StatusCode(StatusCodes.Status400BadRequest, new Responce { status = "Error", Message = "Invalid profile image data." });
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
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("Test-Email")]
        public async Task<IActionResult> TestMail()
        {
            var message = new Message(new string[] { "dhulgandeharidas83@gmail.com" }, "Text", "<h1>Test mail</h1>");
            await _email.SendEmail(message);
            return StatusCode(StatusCodes.Status403Forbidden, new Responce { status = "Success", Message = "Test Mail Send Successfully" });
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>

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

        /// <summary>
        /// Forgot Password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var otp = GenerateRandomOTP();

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var forgotPasswordLink = Url.Action(nameof(ResetPassword), "Authentication", new { token, email = user.Email }, Request.Scheme);

                var message = new Message(new string[] { user.Email! }, "Password Reset OTP", $"Your OTP for password reset is: {otp}");
                await _email.SendEmail(message);

                var resp = new PasswordResetResponse
                {
                    Status = true,
                    Message = "Password reset OTP has been sent to your email",
                    Token = token,
                    Email = email,
                    Otp = otp
                };
                return new ObjectResult(resp)
                {
                    StatusCode = StatusCodes.Status200OK
                };

            }
            return StatusCode(StatusCodes.Status200OK, new Responce { status = "Error", Message = "Failed To send link.. Please try again" , });

        }

        /// <summary>
        /// Resend OTP To User
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("ResendOTP")]
        [AllowAnonymous]
        public async Task<IActionResult> ResendOTP([Required] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var otp = GenerateRandomOTP();

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var forgotPasswordLink = Url.Action(nameof(ResetPassword), "Authentication", new { token, email = user.Email }, Request.Scheme);

                var message = new Message(new string[] { user.Email! }, "Password Reset OTP", $"Your OTP for password reset is: {otp}");
                await _email.SendEmail(message);

                var resp = new PasswordResetResponse
                {
                    Status = true,
                    Message = "Password reset OTP has been sent to your email",
                    Token = token,
                    Email = email,
                    Otp = otp
                };
                return new ObjectResult(resp)
                {
                    StatusCode = StatusCodes.Status200OK
                };

            }
            return StatusCode(StatusCodes.Status200OK, new Responce { status = "Error", Message = "Failed To send link.. Please try again", });

        }

        private string GenerateRandomOTP()
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            return otp.ToString();
        }

        /// <summary>
        /// Reset Password Call Internally
        /// </summary>
        /// <param name="token"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("ResetPassword")]
        public async Task<IActionResult> Resetpassword(string token, string email)
        {
            var model = new PasswordResetResponse { Token = token, Email = email ,Otp = GenerateRandomOTP(), };
            return Ok(new
            {
                model
            });
        }

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Edit Admin Profile
        /// </summary>
        /// <param name="EditProfile"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("EditAdminProfile")]
        public async Task<IActionResult> EditUser([FromBody] EditAdminProfile EditProfile, string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null || EditProfile == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new Responce { status = "Error", Message = "User Not Found" });
                }

                user.FirstName = EditProfile.FirstName;
                user.LastName = EditProfile.LastName;
                user.Email = EditProfile.Email;
                user.Role = EditProfile.Role;
                user.PhoneNumber = EditProfile.ContactNumber;


                var updateResult = await _userManager.UpdateAsync(user);
                if (updateResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK, new Responce { status = "Success", Message = "User Updated Successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Responce { status = "Error", Message = "User Update Failed" });
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


       /// <summary>
       /// Get All User 
       /// </summary>
       /// <returns></returns>
        [Authorize(Roles = "SuperAdmin", AuthenticationSchemes = "Bearer")]
        [HttpGet("GetAllAdminProfiles")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();

                if (users != null)
                {
                    return Ok(users.ToList()); 
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Responce { status = "Error", Message = "Nothing is available Man!!" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get Current Logged-In User
        /// </summary>
        /// <returns></returns>
        
        [Authorize(Roles = "SuperAdmin", AuthenticationSchemes = "Bearer")]
        [HttpGet("GetLoggedInUserProfile")]
        public async Task<IActionResult> GetLoggedInUserProfile(string userName)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                {
                    return BadRequest(new Responce { status  = "Error", Message = "Invalid or missing 'userName' parameter." });
                }
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == userName);

                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound(new Responce { status = "Error", Message = "User not found." });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Change User Password
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [Authorize(Roles = "SuperAdmin", AuthenticationSchemes = "Bearer")]
        [HttpPost("ChangeUserPassword")]
        public async Task<IActionResult> ChangeUserPassword(string userName, [FromBody] ChangeUserPassword changeUserPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(userName) || changeUserPassword == null)
                {
                    return BadRequest(new Responce { status = "Error", Message = "Invalid or missing parameters." });
                }

                // Retrieve the user based on the provided username
                var user = await _userManager.FindByNameAsync(userName);

                if (user == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Responce { status = "Error", Message = "User Not Found." });
                }

                // Verify the current password
                var passwordVerificationResult = await _userManager.CheckPasswordAsync(user, changeUserPassword.CurrentPassword);
                if (!passwordVerificationResult)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Responce { status = "Error", Message = "Current Password Not Matched" });
                }

                // Change the user password
                var changePasswordResult = await _userManager.ChangePasswordAsync(user, changeUserPassword.CurrentPassword, changeUserPassword.NewPassword);

                if (changePasswordResult.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK, new Responce { status = "Success", Message = "Password changed successfully." });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Responce { status = "Error", Message = "An error occurred while changing user password." });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Sonar Test


    }

}

