using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
            if (departments == null)
            {
                return NoContent(); // Return 204 status code for no content
            }
            return Ok(departments);
        }

        [HttpPost]
        [Route("/AddDepartment")]
        public async Task<ActionResult<Departments>> AddDepartment(Departments departments)
        {
            try
            {
                var result = await _departmentsService.AddDepartment(departments);

                if (result != null)
                {
                    return StatusCode(StatusCodes.Status201Created, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.Created,
                        Message = "Department Added Successfully",
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Message = "Department could not be created",
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<string>
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Internal server error occurred.",
                });
            }
        }



        [HttpGet]
        [Route("/GetDepartmentById/{id}")]
        public async Task<ActionResult<Departments>> GetDepartmentById(int id)
        {
            var department = await _departmentsService.GetDepartmentById(id);
            if (department == null)
            {
                return NoContent(); // Return 204 status code for no content
            }
            return Ok(department);
        }

        [HttpPut]
        [Route("/EditDepartment/{id}")]
        public async Task<ActionResult<Departments>> EditDepartment(int id, Departments departments)
        {
            try
            {
                var result = await _departmentsService.EditDepartment(id, departments);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse<Departments>
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Message = "Department not found for the given ID",
                    });
                }

                return StatusCode(StatusCodes.Status200OK, new ApiResponse<Departments>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Department Updated Successfully",
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<Departments>
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Internal server error occurred.",
                });
            }

        }

        [HttpDelete]
        [Route("/DeleteDepartment")]
        public async Task<ActionResult<Departments>> DeleteDepartment(int id)
        {
            try
            {
                var result = await _departmentsService.DeleteDepartment(id);

                if (result != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.OK,
                        Message = "Department Deleted Successfully",
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ApiResponse<string>
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Message = "Department not found",
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<string>
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "Internal server error occurred.",
                });
            }
        }
    }
}
