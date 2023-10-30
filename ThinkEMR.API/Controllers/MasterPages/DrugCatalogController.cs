using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;

namespace ThinkEMR_Care.API.Controllers.MasterPages
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugCatalogController : ControllerBase
    {
        private readonly IDrugCatalogServices _DrugCatalogServices;
        public DrugCatalogController(IDrugCatalogServices DrugCatalogServices)
        {
            _DrugCatalogServices = DrugCatalogServices;
        }

        [HttpGet]
        [Route("/GetAllDrugCatalog")]
        public async Task<ActionResult<List<DrugCatalog>>> GetAllDrugCatalog()
        {
            var result = await _DrugCatalogServices.GetAllDrugCatalog();
            return Ok(result);
        }
        [HttpGet]
        [Route("/FindById/{id}")]
        public async Task<ActionResult<DrugCatalog>> FindById(int id)
        {
            var result = await _DrugCatalogServices.FindById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateDrugCatalog")]
        public async Task<ActionResult<DrugCatalog>> CreateDrugCatalog([FromBody] DrugCatalog drugCatalog)
        {
            var createddrugCatalog = await _DrugCatalogServices.CreateDrugCatalog(drugCatalog);
            return CreatedAtAction("GetAllDrugCatalog", new { id = createddrugCatalog.Id }, createddrugCatalog);
        }
        [HttpPost]
        [Route("UpdateDrugCatalog/{id}")]
        public async Task<IActionResult> UpdateDrugCatalog(int id, [FromBody] DrugCatalog drugCatalog)
        {
            if (id != drugCatalog.Id)
            {
                return BadRequest("Invalid Id");
            }


            var updatedDrugCatalog = await _DrugCatalogServices.UpdateDrugCatalog(drugCatalog);

            if (updatedDrugCatalog == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
