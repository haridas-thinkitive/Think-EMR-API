using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models.Roles_and_Responsibility;
using ThinkEMR_Care.DataAccess.Models.RolesAndResponsibility;

namespace ThinkEMR_Care.DataAccess.Repository.Interface
{
    public interface IRolesAndResponsibilityRepository
    {
        Task<List<RolePermission>> GetRolesAndResponsibility();
        Task<RoleUser> AddNewRole(RoleUser roleUser);
        Task<List<RoleTypes>> GetRoleTypes();
        Task<List<Permission>> GetPermissions();
    }
}
