using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Services;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models.ProviderGroup;

namespace ThinkEMR_Care.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : Controller
    {
        private readonly IProvidersService _providerService;

        public ProvidersController(IProvidersService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProviders()
        {
            try
            {
                var providers = await _providerService.GetAllProvider();
                if (providers == null)
                {
                    return NotFound("No providers found.");
                }
                return Ok(providers);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while fetching providers.");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateNewProvider(Provider provider)
        {
            if (provider == null)
            {
                return BadRequest("Invalid provider data.");
            }

            try
            {
                await _providerService.AddNewProvider(provider);
                return CreatedAtAction(nameof(GetAllProviders), new { id = provider.ProviderId }, provider);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while creating a new provider.");
            }
        }


    }
}
