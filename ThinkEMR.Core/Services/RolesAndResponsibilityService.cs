using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models.Roles_and_Responsibility;
using ThinkEMR_Care.DataAccess.Models.RolesAndResponsibility;
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

        public async Task<List<RolePermission>> GetRolesAndResponsibility()
        {
            return await _rolesAndResponsibilityRepository.GetRolesAndResponsibility();
        }

        public async Task<RoleUser> AddNewRole(RoleUserDTO roleUserr)
        {
            var roleUser = new RoleUser
            {
                RoleName = roleUserr.RoleName,
                RoleType = roleUserr.RoleType.ToString(),
                Permissions = string.Join(", ", roleUserr.SelectedPermissions)
            };

            return await _rolesAndResponsibilityRepository.AddNewRole(roleUser);
        }

        public async Task<List<RoleType>> GetRoleTypes()
        {
            return await _rolesAndResponsibilityRepository.GetRoleTypes();
        }

        public async Task<List<Permission>> GetPermissions()
        {
            return await _rolesAndResponsibilityRepository.GetPermissions();
        }
    }
}
