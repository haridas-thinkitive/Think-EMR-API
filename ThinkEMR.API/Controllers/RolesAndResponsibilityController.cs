using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Models.Roles_and_Responsibility;
using ThinkEMR_Care.DataAccess.Models.RolesAndResponsibility;

namespace ThinkEMR_Care.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesAndResponsibilityController : ControllerBase
    {
        private readonly IRolesAndResponsibilityService _rolesAndResponsibilityService;
        public RolesAndResponsibilityController(IRolesAndResponsibilityService rolesAndResponsibilityService)
        {
            _rolesAndResponsibilityService = rolesAndResponsibilityService;
        }

        [HttpGet]
        [Route("/GetRolesAndResponsibility")]
        public async Task<ActionResult<List<RolePermission>>> GetRolesAndResponsibility()
        {
            var rolesAndResposibility = await _rolesAndResponsibilityService.GetRolesAndResponsibility();
            if (rolesAndResposibility == null)
            {
                return NoContent(); // Return 204 status code for no content
            }
            return Ok(rolesAndResposibility);
        }

        [HttpPost]
        [Route("/AddNewRole")]
        public async Task<ActionResult<RoleUser>> AddNewRole(RoleUserDTO roleUser)
        {
            try
            {
                var result = await _rolesAndResponsibilityService.AddNewRole(roleUser);

                if (result != null)
                {
                    return StatusCode(StatusCodes.Status201Created, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.Created,
                        Message = "New Role Added Successfully",
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "New Roles could not be added."
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<string>
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Internal server error occurred. "
                });
            }
        }

        [HttpGet]
        [Route("/GetRoleTypes")]
        public async Task<ActionResult<List<RoleType>>> GetRoleTypes()
        {
            var roleTypes = await _rolesAndResponsibilityService.GetRoleTypes();
            if (roleTypes == null)
            {
                return NoContent(); // Return 204 status code for no content
            }
            return Ok(roleTypes);
        }

        [HttpGet]
        [Route("/GetPermissions")]
        public async Task<ActionResult<List<Permission>>> GetPermissions()
        {
            var permissions = await _rolesAndResponsibilityService.GetPermissions();
            if (permissions == null)
            {
                return NoContent(); // Return 204 status code for no content
            }
            return Ok(permissions);

        }


    }
}
