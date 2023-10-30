using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;

namespace ThinkEMR_Care.API.Controllers.MasterPages
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPCTCodeCatalogController : ControllerBase
    {
        private readonly ICPCTCodeCatalog _ICPCTCodeServices;
        public CPCTCodeCatalogController(ICPCTCodeCatalog ICPCTCodeServices)
        {
            _ICPCTCodeServices = ICPCTCodeServices;
        }

        [HttpGet]
        [Route("/GetAllCPCTCodeCatalog")]
        public async Task<ActionResult<List<CPTCodeCatalog>>> GetAllCPCTCodeCatalog()
        {
            var result = await _ICPCTCodeServices.GetAllCPCTCodeCatalog();
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateCPCTCodeCatalog")]
        public async Task<ActionResult<CPTCodeCatalog>> CreateCPCTCodeCatalog([FromBody] CPTCodeCatalog cptCodeCatalog)
        {
            var createdCptCodeCatalog = await _ICPCTCodeServices.CreateCPCTCodeCatalog(cptCodeCatalog);
            return CreatedAtAction("GetAllCPCTCodeCatalog", new { id = createdCptCodeCatalog.Id }, createdCptCodeCatalog);
        }
    }
}
