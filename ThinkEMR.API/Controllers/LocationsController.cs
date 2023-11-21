using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var result = await _locationsServices.AddLocations(locations);
            return Ok(result);
        }

        [HttpGet]
        [Route("/GetLocationsById/{id}")]
        public async Task<ActionResult<Locations>> GetLocationsById(int id)
        {
            var location = await _locationsServices.GetLocationsById(id);
            return Ok(location);
        }

        [HttpPut]

        [Route("/EditLocations/{id}")]
        public async Task<ActionResult<Locations>> EditLocations([FromBody] Locations locations, [FromRoute] int id)
        {
            var result = await _locationsServices.EditLocations(id, locations);
            return Ok(result);
        }

        [HttpDelete]
        [Route("/DeletedLocations/{id}")]
        public async Task<ActionResult<Locations>> DeleteLocations(int id)
        {
            var result = await _locationsServices.DeleteLocations(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
