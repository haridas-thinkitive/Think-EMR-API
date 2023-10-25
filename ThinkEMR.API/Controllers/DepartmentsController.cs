using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsService _departmentsService;
        public DepartmentsController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        [HttpGet]
        [Route("/GetDepartments")]
        public async Task<ActionResult<List<Departments>>> GetDepartments()
        {
            var departments = await _departmentsService.GetDepartments();
            return Ok(departments);
        }

        [HttpPost]
        [Route("/AddDepartment")]
        public async Task<ActionResult<Departments>> AddDepartment(Departments departments)
        {
            var department = await _departmentsService.AddDepartment(departments);
            return Ok(department);
        }

        [HttpGet]
        [Route("/GetDepartmentById/{id}")]
        public async Task<ActionResult<Departments>> GetDepartmentById(int id)
        {
            var department = await _departmentsService.GetDepartmentById(id);
            return Ok(department);
        }

        [HttpPut]
        [Route("/EditDepartment/{id}")]
        public async Task<ActionResult<Departments>> EditDepartment(int id, Departments departments)
        {
            var department = await _departmentsService.EditDepartment(id, departments);
            return Ok(department);
        }

        [HttpDelete]
        [Route("/DeleteDepartment")]
        public async Task<ActionResult<Departments>> DeleteDepartment(int id)
        {
            var department = await _departmentsService.DeleteDepartment(id);
            return Ok(department);
        }
    }
}
