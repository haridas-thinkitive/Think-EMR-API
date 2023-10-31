using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models.Roles_and_Responsibility;

namespace ThinkEMR_Care.Core.Services.Interface
{
    public interface IRolesAndResponsibilityService
    {
        //public Task AddNewRoleWithPermission(string roleTypeName, string roleName);
        public Task<IEnumerable<RoleType>> GetAllPermissionWithAllRoleType();
        public Task<IEnumerable<string>> GetPermissionWithRoleType(string roleTypeName);
    }
}
