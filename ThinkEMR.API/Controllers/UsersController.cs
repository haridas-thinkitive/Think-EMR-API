using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThinkEMR_Care.Core.Services;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _usersServices;
        public UsersController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        [HttpGet]
        [Route("/GetStaffUsers")]
        public async Task<ActionResult<List<StaffUser>>> GetStaffUsers()
        {
            var result = await _usersServices.GetStaffUsers();
            if (result == null)
            {
                return NoContent(); // Return 204 status code for no content
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("/AddStaffUsers")]
        public async Task<ActionResult<StaffUser>> AddStaffUsers(StaffUser staffUser)
        {
            try
            {
                var result = await _usersServices.AddStaffUsers(staffUser);

                if (result != null)
                {
                    return StatusCode(StatusCodes.Status201Created, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.Created,
                        Message = "StaffUser Added Successfully",
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "StaffUser could not be created",
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<string>
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Internal server error occurred.",
                });
            }
        }

        [HttpGet]
        [Route("/GetStaffUsersById/{id}")]
        public async Task<ActionResult<StaffUser>> GetStaffUsersById(int id)
        {
            var result = await _usersServices.GetStaffUsersById(id);
            if (result == null)
            {
                return NoContent(); // Return 204 status code for no content
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("/EditStaffUsers/{id}")]
        public async Task<ActionResult<StaffUser>> EditStaffUsers(int id, StaffUser staffUser)
        {
            try
            {
                var result = await _usersServices.EditStaffUsers(id, staffUser);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse<StaffUser>
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Message = "StaffUser not found for the given ID",
                    });
                }

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<StaffUser>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "StaffUser Updated Successfully",
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<StaffUser>
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Internal server error occurred.",
                });
            }
        }
        

        [HttpDelete]
        [Route("/DeleteStaffUsers")]
        public async Task<ActionResult<StaffUser>> DeleteStaffUsers(int id)
        {
            try
            {
                var result = await _usersServices.DeleteStaffUsers(id);
                if (result != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.OK,
                        Message = "StaffUser Deleted Successfully",
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Message = "StaffUser not found",
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<string>
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Internal server error occurred.",
                });
            }
        }

        /// <summary>
        /// Provider User
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("/GetProviderUsers")]
        public async Task<ActionResult<List<ProviderUser>>> GetProviderUsers()
        {
            var result = await _usersServices.GetProviderUsers();
            if(result == null)
            {
                return NoContent(); //Returns 204 status code for no content
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("/AddProviderUsers")]
        public async Task<ActionResult<ProviderUser>> AddProviderUsers(ProviderUser providerUser)
        {
            try
            {
                var result = await _usersServices.AddProviderUsers(providerUser);

                if(result != null)
                {
                    return StatusCode(StatusCodes.Status201Created, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.Created,
                        Message = "ProviderUser Added Successfully."
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "ProviderUser could not be created."
                    });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<string>
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Internal Server Error Occurred."
                });
            }
        }

    }
}
