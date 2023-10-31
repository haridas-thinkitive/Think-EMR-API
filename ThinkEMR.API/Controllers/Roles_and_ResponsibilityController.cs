using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Data;

namespace ThinkEMR_Care.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Roles_and_ResponsibilityController : ControllerBase
    {
        private readonly IRolesAndResponsibilityService _rolesAndResponsibilityService;
        public Roles_and_ResponsibilityController(IRolesAndResponsibilityService rolesAndResponsibilityService)
        {
            _rolesAndResponsibilityService = rolesAndResponsibilityService;
        }


        [HttpGet("allPermissions")]
        public async Task<IActionResult> GetAllPermissionWithAllRoleType()
        {
            try
            {
                var permissions = await _rolesAndResponsibilityService.GetAllPermissionWithAllRoleType();
                if (permissions == null)
                {
                    return NotFound("No providers found.");
                }
                return Ok(permissions);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while fetching Role and Permissions.");
            }
        }

        [HttpGet("rolePermissions")]
        public async Task<IActionResult> GetPermissionWithRoleType(string roleTypeName)
        {
            string roleName = roleTypeName;


            try
            {
                var permissionNames = await _rolesAndResponsibilityService.GetPermissionWithRoleType(roleName);
                if (permissionNames == null)
                {
                    return NotFound("No providers found.");
                }
                return Ok(permissionNames);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching permissions.");
            }
        }
    }
}
