using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.API.Controllers
{
    [Authorize(Roles ="Admin1", AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardDetailsController : ControllerBase
    {
        private readonly IDashboardDetails _dashboardDetails;

        public DashboardDetailsController(IDashboardDetails dashboardDetails)
        {
            _dashboardDetails = dashboardDetails;
        }

        [Route("/GetCount")]
        [HttpGet] 
        public async Task<ActionResult<DashboardCount>> GetLatestDashboardCount()
        {
            var result = await _dashboardDetails.GetLatestDashboardCount();
            return Ok(result);
        }

        [Route("DashboardDetailsInfo")]
        [HttpGet]
        public async Task<ActionResult<List<DashboardData>>> DashboardDetails()
        {
            var result = await _dashboardDetails.DashboardDetails();
            return Ok(result);
        }
    }
}
