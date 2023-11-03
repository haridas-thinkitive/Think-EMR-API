using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.Core.Services
{
    public class ProviderGroupsService : IProviderGroupsService
    {
        private readonly IProviderGroupsRepository _providerGroupsRepository;

        public ProviderGroupsService(IProviderGroupsRepository providerGroupsRepository)
        {
            _providerGroupsRepository = providerGroupsRepository;
        }

        public async Task<List<ProviderGroupProfile>> GetProviderGroups()
        {
            return await _providerGroupsRepository.GetProviderGroups();
        }

        public async Task<ProviderGroupProfile> AddProviderGroups(ProviderGroupProfile providerGroupProfile)
        {
            return await _providerGroupsRepository.AddProviderGroups(providerGroupProfile);
        }

        public async Task<ProviderGroupProfile> GetProviderGroupsById(int id)
        {
            return await _providerGroupsRepository.GetProviderGroupsById(id);
        }

        public async Task<ProviderGroupProfile> EditProviderGroups(int id, ProviderGroupProfile providerGroupProfile)
        {
            return await _providerGroupsRepository.EditProviderGroups(id, providerGroupProfile);
        }

        public async Task<ProviderGroupProfile> DeleteProviderGroups(int id)
        {
            return await _providerGroupsRepository.DeleteProviderGroups(id);
        }
    }
}
