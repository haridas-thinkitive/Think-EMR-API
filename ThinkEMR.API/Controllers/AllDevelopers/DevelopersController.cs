using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Interface.DevelopersMain;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.API.Controllers.AllDevelopers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IDevelopers _developers;

        public DevelopersController(IDevelopers developers)
        {
            _developers = developers;
        }

        [HttpGet]
        [Route("/AllDevelopers")]
        public async Task<ActionResult<List<Collaborator>>> getAllCollaborators()
        {
            var result = await _developers.getAllCollaborators();
            return Ok(result);
        }

    }
}
