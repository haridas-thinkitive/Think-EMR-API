using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.Core.Services.Interface
{
    public interface IUsersServices
    {
        Task<List<StaffUser>> GetStaffUsers();
        Task<StaffUser> AddStaffUsers(StaffUser staffUser);
        Task<StaffUser> GetStaffUsersById(int id);
        Task<StaffUser> EditStaffUsers(int id, StaffUser staffUser);
        Task<StaffUser> DeleteStaffUsers(int id);

        /// <summary>
        /// Provider users
        /// </summary>
        /// <returns></returns>
        
        Task<List<ProviderUser>> GetProviderUsers();
        Task<ProviderUser> AddProviderUsers(ProviderUser providerUser);
    }
}
