using ThinkEMR_Care.DataAccess.Models.Roles_and_Responsibility;
using ThinkEMR_Care.DataAccess.Models.RolesAndResponsibility;

namespace ThinkEMR_Care.Core.Services.Interface
{
    public interface IRolesAndResponsibilityService
    {
        Task<List<RolePermission>> GetRolesAndResponsibility();

        Task<RoleUser> AddNewRole(RoleUserDTO roleUser);

        Task <List<RoleType>> GetRoleTypes();

        Task <List<Permission>> GetPermissions();


    }
}
