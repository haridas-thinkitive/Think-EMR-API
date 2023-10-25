using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmtpServer.Text;
using System.ComponentModel.DataAnnotations;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models.Authentication.Login;
using ThinkEMR_Care.DataAccess.Models.Authentication.SignUp;
using ThinkEMR_Care.DataAccess.Models.EmailConfig;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationServices;
        public AuthenticationController(IAuthenticationServices authenticationServices)
        {
            _authenticationServices = authenticationServices;

        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterNewUser([FromBody] RegisterUser registerUser, string role)
        {
            var result = await _authenticationServices.RegisterNewUser(registerUser,role);
            return Ok(result);
        }

        [HttpGet("ConformEmail")]
        public async Task<IActionResult> ConformEmail()
        {
            var result = await _authenticationServices.ConformEmail();
            return Ok(result);
        }

        [HttpGet("ConformUserDB")]
        public async Task<IActionResult> ConformUserDB(string token,string email)
        {
            var result = await _authenticationServices.ConformUserDB(token, email);
            return Ok(result);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel loginModel)
        {
            var result = await _authenticationServices.LoginUser(loginModel);
            return Ok(result);
        }

        [HttpPost("Forgotpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            var result = await _authenticationServices.ForgotPassword(email);
            return Ok(result);
        }

        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([Required] string email)
        {
            var result = await _authenticationServices.ResetPassword(email);
            return Ok(result);
        }

        [HttpPost("Reset-password")]
        public async Task<IActionResult> ResetPassword(string Token, string Email)
        {
            var result = await _authenticationServices.ResetPassword(Token, Email);
            return Ok(result);
           
        }

        
    }
}
