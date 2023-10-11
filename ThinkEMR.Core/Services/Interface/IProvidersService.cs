using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models.ProviderGroup;

namespace ThinkEMR_Care.Core.Services.Interface
{
    public interface IProvidersService
    {
        public Task AddNewProvider(Provider provider);
        public Task<IEnumerable<Provider>> GetAllProvider();
    }
}
