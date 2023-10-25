using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.Core.Services.Interface
{
    public interface IProviderGroupsService
    {
        Task<List<ProviderGroupProfile>> GetProviderGroups();

        Task<ProviderGroupProfile> AddProviderGroups(ProviderGroupProfile providerGroupProfile);

        Task<ProviderGroupProfile> GetProviderGroupsById(int id);

        Task<ProviderGroupProfile> EditProviderGroups(int id, ProviderGroupProfile providerGroupProfile);

        Task<ProviderGroupProfile> DeleteProviderGroups(int id);
    }
}
