using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess;
using ThinkEMR_Care.DataAccess.Models.ProviderGroup;
using ThinkEMR_Care.DataAccess.Repository.ProviderRepository;

namespace ThinkEMR_Care.Core.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }
        public async Task AddNewProvider(Provider provider)
        {
            await _providerRepository.CreateProviderAsync(provider);
        }
        public async Task<IEnumerable<Provider>> GetAllProvider()
        {
            var providers = await _providerRepository.GetAllProviderAsync();
            return providers;
        }
    }
}
