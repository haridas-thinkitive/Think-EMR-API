using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Services;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models.ProviderGroup;

namespace ThinkEMR_Care.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : Controller
    {
        private readonly IProviderService _providerService;
        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;        
        }

        [HttpGet]
        public async Task<IEnumerable<Provider>> GetAllProviders()
        {
            var providers=await _providerService.GetAllProvider();
            return providers;
            
        }

        [HttpPost]
        public async Task CreateNewProvider(Provider provider)
        {
            await _providerService.AddNewProvider(provider);
        }


    }
}
