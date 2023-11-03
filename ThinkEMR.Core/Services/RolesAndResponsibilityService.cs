using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models.Roles_and_Responsibility;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.Core.Services
{
    public class RolesAndResponsibilityService : IRolesAndResponsibilityService
    {
        private readonly IRolesAndResponsibilityRepository _rolesAndResponsibilityRepository;
        public RolesAndResponsibilityService(IRolesAndResponsibilityRepository rolesAndResponsibilityRepository)
        {
            _rolesAndResponsibilityRepository = rolesAndResponsibilityRepository;

        }
        public async Task<IEnumerable<RoleType>> GetAllPermissionWithAllRoleType()
        {
            var permissions = await _rolesAndResponsibilityRepository.GetAllPermissionWithAllRoleType();
            return permissions;
        }

        public async Task<IEnumerable<string>> GetPermissionWithRoleType(string roleTypeName)
        {
            string roleType = roleTypeName;
            var permissions = await _rolesAndResponsibilityRepository.GetPermissionWithRoleType(roleType);
            return permissions;
        }
    }
}
