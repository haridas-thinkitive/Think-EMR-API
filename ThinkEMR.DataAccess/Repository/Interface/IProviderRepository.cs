using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models.ProviderGroup;

namespace ThinkEMR_Care.DataAccess.Repository.ProviderRepository
{
    public interface IProviderRepository
    {
        public Task CreateProviderAsync(Provider provider);
        public Task<IEnumerable<Provider>> GetAllProviderAsync();
    }
}
