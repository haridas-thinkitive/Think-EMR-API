using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderGroupsController : ControllerBase
    {
        private readonly IProviderGroupsService _providerGroupsServices;
        public ProviderGroupsController(IProviderGroupsService providerGroupsServices)
        {
            _providerGroupsServices = providerGroupsServices;
        }

        [HttpGet]
        [Route("/GetProviderGroups")]
        public async Task<ActionResult<List<ProviderGroupProfile>>> GetProviderGroups()
        {
            var result = await _providerGroupsServices.GetProviderGroups();
            if (result == null)
            {
                return NoContent(); // Return 204 status code for no content
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("/AddProviderGroups")]
        public async Task<ActionResult<ApiResponse<string>>> AddProviderGroups([FromBody] ProviderGroupProfile providerGroupProfile)
        {
            try
            {
                var result = await _providerGroupsServices.AddProviderGroups(providerGroupProfile);

                if (result != null)
                {
                    return StatusCode(StatusCodes.Status201Created, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.Created,
                        Message = "ProviderGroup Added Successfully",
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "ProviderGroup could not be created",
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
        [Route("/GetProviderGroupsById/{id}")]
        public async Task<ActionResult<ProviderGroupProfile>> GetProviderGroupsById(int id)
        {
            var result = await _providerGroupsServices.GetProviderGroupsById(id);
            if (result == null)
            {
                return NoContent(); // Return 204 status code for no content
            }
            return Ok(result);
        }


        [HttpPut]
        [Route("/EditProviderGroups/{id}")]
        public async Task<ActionResult<ApiResponse<ProviderGroupProfile>>> EditProviderGroups([FromBody] ProviderGroupProfile providerGroupProfile, [FromRoute] int id)
        {
            try
            {
                var result = await _providerGroupsServices.EditProviderGroups(id, providerGroupProfile);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse<ProviderGroupProfile>
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Message = "ProviderGroup not found for the given ID",
                    });
                }

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<ProviderGroupProfile>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "ProviderGroup Updated Successfully",
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<ProviderGroupProfile>
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Internal server error occurred.",
                });
            }
        }



        [HttpDelete]
        [Route("/DeleteProviderGroups/{id}")]
        public async Task<ActionResult<ApiResponse<string>>> DeleteProviderGroups(int id)
        {
            try
            {
                var result = await _providerGroupsServices.DeleteProviderGroups(id);

                if (result != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.OK,
                        Message = "ProviderGroup Deleted Successfully",
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Message = "ProviderGroup not found",
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


    }
}
