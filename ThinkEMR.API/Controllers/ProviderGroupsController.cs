using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(result);
        }

        [HttpPost]
        [Route("/AddProviderGroups")]
        public async Task<ActionResult<ProviderGroupProfile>> AddProviderGroups([FromBody] ProviderGroupProfile providerGroupProfile)
        {
            var result = await _providerGroupsServices.AddProviderGroups(providerGroupProfile);
            return Ok(result);
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
        public async Task<ActionResult<ProviderGroupProfile>> EditProviderGroups([FromBody] ProviderGroupProfile providerGroupProfile, [FromRoute] int id)
        {
            var result = await _providerGroupsServices.EditProviderGroups(id, providerGroupProfile);
            return Ok(result);
        }

        [HttpDelete]
        [Route("/DeleteProviderGroups/{id}")]
        public async Task<ActionResult<ProviderGroupProfile>> DeleteProviderGroups(int id)
        {
            var result = await _providerGroupsServices.DeleteProviderGroups(id);
            return Ok(result);
        }

    }
}
