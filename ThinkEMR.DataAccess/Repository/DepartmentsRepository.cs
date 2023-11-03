using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Data;
//using ThinkEMR_Care.DataAccess.Migrations;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.DataAccess.Repository
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Departments>> GetDepartments()
        {
            try
            {
                return await _context.departments.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Departments> AddDepartment(Departments departments)
        {
            try
            {
                _context.departments.Add(departments);
                await _context.SaveChangesAsync();
                return departments;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Departments> GetDepartmentById(int id)
        {
            try
            {
                var department = await _context.departments.Where(d => d.Id == id).FirstOrDefaultAsync();
                if (department != null)
                {
                    return department;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Departments> EditDepartment(int id, Departments departments)
        {
            try
            {
                var existingDepartment = await _context.departments.FirstOrDefaultAsync(x => x.Id == departments.Id);

                if (existingDepartment == null)
                {
                    return null;
                }
                _context.Entry(existingDepartment).CurrentValues.SetValues(departments);
                
                await _context.SaveChangesAsync();

                return departments;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Departments> DeleteDepartment(int id)
        {
            try
            {
                var result = await _context.departments.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.departments.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }

}
