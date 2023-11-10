using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Services;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _usersServices;
        public UsersController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        [HttpGet]
        [Route("/GetStaffUsers")]
        public async Task<ActionResult<List<StaffUser>>> GetStaffUsers()
        {
            var result = await _usersServices.GetStaffUsers();
            return Ok(result);
        }

        [HttpPost]
        [Route("/AddStaffUsers")]
        public async Task<ActionResult<StaffUser>> AddStaffUsers(StaffUser staffUser)
        {
            var result = await _usersServices.AddStaffUsers(staffUser);
            return Ok(result);
        }

        [HttpGet]
        [Route("/GetStaffUsersById/{id}")]
        public async Task<ActionResult<StaffUser>> GetStaffUsersById(int id)
        {
            var result = await _usersServices.GetStaffUsersById(id);
            return Ok(result);
        }

        [HttpPut]
        [Route("/EditStaffUsers/{id}")]
        public async Task<ActionResult<StaffUser>> EditStaffUsers(int id, StaffUser staffUser)
        {
            var result = await _usersServices.EditStaffUsers(id, staffUser);
            return Ok(result);
        }

        [HttpDelete]
        [Route("/DeleteStaffUsers")]
        public async Task<ActionResult<StaffUser>> DeleteStaffUsers(int id)
        {
            var result = await _usersServices.DeleteStaffUsers(id);
            return Ok(result);
        }
    }
}
