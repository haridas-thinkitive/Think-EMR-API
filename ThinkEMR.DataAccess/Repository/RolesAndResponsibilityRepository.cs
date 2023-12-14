using Microsoft.EntityFrameworkCore;
using ThinkEMR_Care.DataAccess.Data;
using ThinkEMR_Care.DataAccess.Models.Roles_and_Responsibility;
using ThinkEMR_Care.DataAccess.Models.RolesAndResponsibility;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.DataAccess.Repository
{
    public class RolesAndResponsibilityRepository : IRolesAndResponsibilityRepository
    {
        private readonly ApplicationDbContext _context;

        public RolesAndResponsibilityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RolePermission>> GetRolesAndResponsibility()
        {
            var rolesAndResponsibility = await _context.RolePermissions
                    .Include(p => p.RoleType)
                    .Include(p => p.Permission)
                    .ToListAsync();
            try
            {
                return rolesAndResponsibility.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<RoleUser> AddNewRole(RoleUser roleUser)
        {
            try
            {
                _context.RoleUsers.Add(roleUser);
                await _context.SaveChangesAsync();
                return roleUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<RoleType>> GetRoleTypes()
        {
            var roleType = await _context.RoleTypes.ToListAsync();
            try
            {
                return roleType.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Permission>> GetPermissions()
        {
            var permission = await _context.Permissions.ToListAsync();
            try
            {
                return permission.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
    }

}
