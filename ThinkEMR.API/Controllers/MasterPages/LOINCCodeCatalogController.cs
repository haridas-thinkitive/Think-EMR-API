using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;

namespace ThinkEMR_Care.API.Controllers.MasterPages
{
    [Route("api/[controller]")]
    [ApiController]
    public class LOINCCodeCatalogController : ControllerBase
    {
        private readonly ILOINCCodeServices _LOINCCodeServices;
        public LOINCCodeCatalogController(ILOINCCodeServices LOINCCodeServices)
        {
            _LOINCCodeServices = LOINCCodeServices;
        }

        [HttpGet]
        [Route("/GetAllLOINC")]
        public async Task<ActionResult<List<LOINCCodeCatalog>>> GetAllLOINC()
        {
            var result = await _LOINCCodeServices.GetAllLOINC();
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateLOINCCodeCatalog")]
        public async Task<ActionResult<LOINCCodeCatalog>> CreateLOINCCodeCatalog([FromBody] LOINCCodeCatalog loincCodeCatalog)
        {
            var createdloincCodeCatalog = await _LOINCCodeServices.CreateLOINCCodeCatalog(loincCodeCatalog);
            return CreatedAtAction("GetAllLOINC", new { id = createdloincCodeCatalog.Id }, createdloincCodeCatalog);
        }

    }
}
