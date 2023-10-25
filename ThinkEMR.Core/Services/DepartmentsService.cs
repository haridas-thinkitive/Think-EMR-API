using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.Core.Services
{

    public class DepartmentsService : IDepartmentsService
    {
        private readonly IDepartmentsRepository _departmentsRepository;
        public DepartmentsService(IDepartmentsRepository departmentsRepository)
        {
            _departmentsRepository = departmentsRepository;
        }

        public async Task<List<Departments>> GetDepartments()
        {
            return await _departmentsRepository.GetDepartments();
        }

        public async Task<Departments> AddDepartment(Departments departments)
        {
            return await _departmentsRepository.AddDepartment(departments);
        }

        public async Task<Departments> GetDepartmentById(int id)
        {
            return await _departmentsRepository.GetDepartmentById(id);
        }

        public async Task<Departments> EditDepartment(int id, Departments departments)
        {
            return await _departmentsRepository.EditDepartment(id, departments);
        }

        public async Task<Departments> DeleteDepartment(int id)
        {
            return await _departmentsRepository.DeleteDepartment(id);
        }

    }
}
