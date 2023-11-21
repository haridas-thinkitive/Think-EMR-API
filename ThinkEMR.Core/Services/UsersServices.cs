using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Repository;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.Core.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IUsersRepository _usersRepository;
        public UsersServices(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<List<StaffUser>> GetStaffUsers()
        {
            return await _usersRepository.GetStaffUsers();
        }

        public async Task<StaffUser> AddStaffUsers(StaffUser staffUser)
        {
            return await _usersRepository.AddStaffUsers(staffUser);
        }

        public async Task<StaffUser> GetStaffUsersById(int id)
        {
            return await _usersRepository.GetStaffUsersById(id);
        }

        public async Task<StaffUser> EditStaffUsers(int id, StaffUser staffUser)
        {
            return await _usersRepository.EditStaffUsers(id, staffUser);
        }

        public async Task<StaffUser> DeleteStaffUsers(int id)
        {
            return await _usersRepository.DeleteStaffUsers(id);
        }

        /// <summary>
        /// Provider Users
        /// </summary>
        /// <returns></returns>

        public async Task<List<ProviderUser>> GetProviderUsers()
        {
            return await _usersRepository.GetProviderUsers();
        }

        public async Task<ProviderUser> AddProviderUsers(ProviderUser providerUser)
        {
            return await _usersRepository.AddProviderUsers(providerUser);
        }

    }
}
