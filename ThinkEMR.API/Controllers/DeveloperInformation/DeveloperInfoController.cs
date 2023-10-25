using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Services.IServices.IDeveloperInformationServices;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.API.Controllers.DeveloperInformation
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperInfoController : ControllerBase
    {
        private readonly IDeveloperInfoService _developerInfoServices;
        public DeveloperInfoController(IDeveloperInfoService developerInfoServices)
        {
           _developerInfoServices = developerInfoServices;
        }

        [HttpGet]
        [Route("/GetAllDeveloper")]
        public async Task<ActionResult<List<Collaborator>>> GetAllDeveloper()
        {
            var result = await _developerInfoServices.GetAllDeveloper();
            return Ok(result);
        }
    }
}
