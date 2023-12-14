using ThinkEMR_Care.DataAccess.Models.Roles_and_Responsibility;
using ThinkEMR_Care.DataAccess.Models.RolesAndResponsibility;

namespace ThinkEMR_Care.DataAccess.Repository.Interface
{
    public interface IRolesAndResponsibilityRepository
    {
        Task<List<RolePermission>> GetRolesAndResponsibility();
        Task<RoleUser> AddNewRole(RoleUser roleUser);
        Task<List<RoleType>> GetRoleTypes();
        Task<List<Permission>> GetPermissions();
    }
}
