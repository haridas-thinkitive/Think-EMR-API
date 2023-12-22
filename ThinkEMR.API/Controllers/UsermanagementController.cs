using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;
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
            if(result > 0)
            {
                return StatusCode(StatusCodes.Status200OK, new APIReturnViewModel<IActionResult>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "User Created Successfully...!!!",
                    Count = result

                    
                });;
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, new APIReturnViewModel<IActionResult>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "User Not Created Something is Wrong Please Check...!!",
                    Count = result
                });
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel loginModel)
        {
            var result = await _userManagement.LoginUser(loginModel);
            return Ok(result);
        }


        [Authorize(Roles = "SuperAdmin", AuthenticationSchemes = "Bearer")]
        [HttpPost("SendNotificationToUser")]
        public async Task<IActionResult> SendNotificationToUser(string Touser, string FromUser)
        {
            var Result = await _userManagement.SendNotificationToUser(Touser, FromUser);
            if (Result > 0)
            {
                return StatusCode(StatusCodes.Status200OK, new APIReturnViewModel<string>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Notification Send Successfully...!",
                    Count = Result,
                    Result = "Notification Received From" + " "+ FromUser
                }); ;
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, new APIReturnViewModel<string>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Something is wrong Please Chaeck again..",
                    Count = Result
                });
            }
        }



    }
}
