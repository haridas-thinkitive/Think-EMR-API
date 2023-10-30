using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;

namespace ThinkEMR_Care.API.Controllers.MasterPages
{
    [Route("api/[controller]")]
    [ApiController]
    public class HCPCSCodeCatalogController : ControllerBase
    {
        private readonly IHCPCSCodeCatalogServices _IHCPCSCodeServices;
        public HCPCSCodeCatalogController(IHCPCSCodeCatalogServices IHCPCSCodeServices)
        {
            _IHCPCSCodeServices = IHCPCSCodeServices;
        }

        [HttpGet]
        [Route("/GetAllHCPCSCodeCatalog")]
        public async Task<ActionResult<List<HCPCSCodeCatalog>>> GetAllHCPCSCodeCatalog()
        {
            var result = await _IHCPCSCodeServices.GetAllHCPCSCodeCatalog();
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateHCPCSCodeCatalog")]
        public async Task<ActionResult<HCPCSCodeCatalog>> CreateHCPCSCodeCatalog([FromBody] HCPCSCodeCatalog hcpcsCodeCatalog)
        {
            var createdHcpcsCodeCatalog = await _IHCPCSCodeServices.CreateHCPCSCodeCatalog(hcpcsCodeCatalog);
            return CreatedAtAction("GetAllHCPCSCodeCatalog", new { id = createdHcpcsCodeCatalog.Id }, createdHcpcsCodeCatalog);
        }
    }
}
