using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models.Authentication.Login;
using ThinkEMR_Care.DataAccess.Models.Authentication.SignUp;

namespace ThinkEMR_Care.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsermanagementController : ControllerBase
    {
        private readonly IUserManagement _userManagement;

        public UsermanagementController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string Role)
        {
            var result = await _userManagement.RegisterUser(registerUser,Role);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel loginModel)
        {
            var result = await _userManagement.LoginUser(loginModel);
            return Ok(result);
        }

    }
}
