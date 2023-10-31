using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Data;
using ThinkEMR_Care.DataAccess.Models.Roles_and_Responsibility;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.DataAccess.Repository
{
    public class RolesAndResponsibilityRepository : IRolesAndResponsibilityRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RolesAndResponsibilityRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public async Task AddNewRoleWithPermission(string roleTypeName, string roleName)
        //{
        //    try
        //    {
        //        var roleType = await _dbContext.RoleTypes.FirstOrDefaultAsync(r => r.RoleTypeName == roleTypeName);

        //        if (roleType == null)
        //        {
        //            return NotFound("No RoleType Found");
        //        }
        //        else
        //        {
        //            int roleTypeId = Convert.ToInt32(roleType.RoleTypeId);
        //            var existingRole = await _dbContext.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);

        //            if (existingRole != null)
        //            {
        //                return Conflict("Role already exists");
        //            }

        //            var newRole = new Role
        //            {
        //                RoleName = roleName,
        //                RoleTypeId = roleTypeId
        //            };

        //            _dbContext.Roles.Add(newRole);
        //            await _dbContext.SaveChangesAsync();

        //            List<int> permissionIds = await _dbContext.Permissions
        //                .Where(p => p.RoleTypeId == roleTypeId)
        //                .Select(p => p.PermissionId)
        //                .ToListAsync();

        //            var role = _dbContext.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
        //            if (role == null)
        //            {
        //                return NotFound("No Role Found");
        //            }
        //            else
        //            {
        //                int roleId = Convert.ToInt32(role.Result.RoleId);

        //                foreach (int permissionId in permissionIds)
        //                {
        //                    // Create a new RolePermission entry for each role-permission relationship
        //                    var rolePermission = new RolePermission
        //                    {
        //                        RoleId = roleId,
        //                        PermissionId = permissionId
        //                    };

        //                    // Add the rolePermission to the DbContext
        //                    _dbContext.RolePermissions.Add(rolePermission);
        //                    //await _dbContext.SaveChangesAsync();

        //                }
        //            }
        //            await _dbContext.SaveChangesAsync();

        //            return StatusCode(201, "Role Added successfully ");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ("An error occurred while fetching Permissions.");
        //    }

        //}

        public async Task<IEnumerable<RoleType>> GetAllPermissionWithAllRoleType()
        {
            var roleTypes = await _dbContext.RoleTypes.Include(rt => rt.Permissions).ToListAsync();

            var roleTypeResponses = new List<RoleType>();

            foreach (var roleType in roleTypes)
            {
                var permissions = roleType.Permissions.ToList();
                var response = new RoleType
                {
                    RoleTypeId = roleType.RoleTypeId,
                    RoleTypeName = roleType.RoleTypeName,
                    Permissions = permissions
                };
                roleTypeResponses.Add(response);
            }

            return roleTypeResponses;
        }

        public async Task<IEnumerable<string>> GetPermissionWithRoleType(string roleTypeName)
        {
            var roleType = _dbContext.RoleTypes.FirstOrDefaultAsync(rt => rt.RoleTypeName == roleTypeName);

            int roleTypeId = Convert.ToInt32(roleType.Result.RoleTypeId);

            var permissionNames = await _dbContext.Permissions
                        .Where(p => p.RoleTypeId == roleTypeId)
                        .Select(p => p.PermissionName)
                        .ToListAsync();
            return permissionNames;
        }
    }

}
