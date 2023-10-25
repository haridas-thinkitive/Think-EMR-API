using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.DataAccess.Repository.Interface
{
    public interface IDepartmentsRepository
    {
        Task<List<Departments>> GetDepartments();
        Task<Departments> AddDepartment(Departments departments);
        Task<Departments> GetDepartmentById(int id);
        Task<Departments> EditDepartment(int id, Departments departments);
        Task<Departments> DeleteDepartment(int id);
    }
}
