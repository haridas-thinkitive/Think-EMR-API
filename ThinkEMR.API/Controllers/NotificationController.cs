using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        /// <summary>
        /// Get Specific Notification By User Name
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetNotificationByID")]
        public async Task<ActionResult<List<Notification>>> GetUnreadNotifications(string username)
        {
            var notifications = await _notificationService.GetUnreadNotifications(username);
            if (notifications != null)
            {
                return Ok(notifications);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, new Responce
                {
                    status = StatusCodes.Status404NotFound.ToString(),
                    Message = "User Not Found...!!!"
                }) ;
            }
        }


        /// <summary>
        /// Get All Notification From Database
        /// </summary>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetAllNotification")]
        public async Task<ActionResult<List<Notification>>> GetAllNotification()
        {
            var notifications = await _notificationService.GetAllNotification();
            return Ok(notifications);
        }


        /// <summary>
        /// Post/Set Notification IsRead=1 If notification is read by user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("MarkAsRead/{id}")]
        public async Task<ActionResult<Notification>> MarkNotificationAsRead(int id)
        {
            var notifications = await _notificationService.MarkNotificationAsRead(id);
            if (notifications != null)
            {
                return StatusCode(StatusCodes.Status200OK, new APIReturnViewModel<Notification>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Record Update Successfully...!!!",
                    Result = notifications
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, new APIReturnViewModel<Notification>
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Notification IsRead not Updated",
                });
            }
        }

    }
}
