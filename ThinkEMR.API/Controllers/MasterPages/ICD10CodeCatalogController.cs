using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;

namespace ThinkEMR_Care.API.Controllers.MasterPages
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICD10CodeCatalogController : ControllerBase
    {
        private readonly IICD10CodeCatalogServices _ICD10CodeServices;
        public ICD10CodeCatalogController(IICD10CodeCatalogServices ICD10CodeServices)
        {
            _ICD10CodeServices = ICD10CodeServices;
        }

        [HttpGet]
        [Route("/GetAllICD10CodeCatalog")]
        public async Task<ActionResult<List<ICD10CodeCatalog>>> GetAllICD10CodeCatalog()
        {
            var result = await _ICD10CodeServices.GetAllICD10CodeCatalog();
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateICD10CodeCatalog")]
        public async Task<ActionResult<ICD10CodeCatalog>> CreateICD10CodeCatalog([FromBody] ICD10CodeCatalog icd10CodeCatalog)
        {
            var createdIcd10CodeCatalog = await _ICD10CodeServices.CreateICD10CodeCatalog(icd10CodeCatalog);
            return CreatedAtAction("GetAllICD10CodeCatalog", new { id = createdIcd10CodeCatalog.Id }, createdIcd10CodeCatalog);
        }
    }
}
