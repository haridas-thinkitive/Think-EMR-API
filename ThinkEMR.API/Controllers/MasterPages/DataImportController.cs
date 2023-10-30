using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;

namespace ThinkEMR_Care.API.Controllers.MasterPages
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataImportController : ControllerBase
    {
        private readonly IDataImportServices _DataImportServices;
        public DataImportController(IDataImportServices DataImportServices)
        {
            _DataImportServices = DataImportServices;
        }

        [HttpGet]
        [Route("/GetAllDataImport")]
        public async Task<ActionResult<List<DataImport>>> GetAllDataImport()
        {
            var result = await _DataImportServices.GetAllDataImport();
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateDataImport")]
        public async Task<ActionResult<DataImport>> CreateDataImport([FromBody] DataImport dataImport)
        {
            var createdDataImport = await _DataImportServices.CreateDataImport(dataImport);
            return CreatedAtAction("CreateDataImport", new { id = createdDataImport.Id }, createdDataImport);
        }
    }
}
