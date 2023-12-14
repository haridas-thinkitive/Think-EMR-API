using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Models.Roles_and_Responsibility;
using ThinkEMR_Care.DataAccess.Models.RolesAndResponsibility;

namespace ThinkEMR_Care.Core.Services.Interface
{
    public interface IRolesAndResponsibilityService
    {
        Task<List<RolePermission>> GetRolesAndResponsibility();

        Task<RoleUser> AddNewRole(RoleUserDTO roleUser);

        Task <List<RoleTypes>> GetRoleTypes();

        Task <List<Permission>> GetPermissions();


    }
}
