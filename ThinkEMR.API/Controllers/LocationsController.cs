using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsService _locationsServices;

        public LocationsController(ILocationsService locationsServices)
        {
            _locationsServices = locationsServices;
        }

        [HttpGet]
        [Route("/GetLocations")]
        public async Task<ActionResult<List<Locations>>> GetLocations()
        {
            var location = await _locationsServices.GetLocations();
            return Ok(location);
        }

        [HttpPost]
        [Route("/AddLocations")]
        public async Task<ActionResult<Locations>> AddLocations(Locations locations)
        {
            try
            {
                var result = await _locationsServices.AddLocations(locations);

                if (result != null)
                {
                    return StatusCode(StatusCodes.Status201Created, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.Created,
                        Message = "Location Added Successfully",
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "Location could not be added."
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
        [Route("/GetLocationsById/{id}")]
        public async Task<ActionResult<Locations>> GetLocationsById(int id)
        {
            var location = await _locationsServices.GetLocationsById(id);
            if(location == null)
            {
                return NoContent();
            }
            return Ok(location);
        }

        [HttpPut]

        [Route("/EditLocations/{id}")]
        public async Task<ActionResult<Locations>> EditLocations([FromBody] Locations locations, [FromRoute] int id)
        {
            try
            {
                var result = await _locationsServices.EditLocations(id, locations);

                if(result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse<Locations>
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Message = "Location not found.",
                    });
                }
                return StatusCode(StatusCodes.Status200OK, new ApiResponse<Locations>
                {
                    StatusCode = (int)(HttpStatusCode.OK),
                    Message = "Location Updated Successfully"
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<Locations>
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Internal server error occurred."
                });
            }

        }

        [HttpDelete]
        [Route("/DeletedLocations/{id}")]
        public async Task<ActionResult<Locations>> DeleteLocations(int id)
        {
            try
            {
                var result = await _locationsServices.DeleteLocations(id);
                if (result != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.OK,
                        Message = "Location Deleted Successfully",
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Message = "Location not found",
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
