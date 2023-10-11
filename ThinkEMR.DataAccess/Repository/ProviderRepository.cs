using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Data;
using ThinkEMR_Care.DataAccess.Models.ProviderGroup;
using ThinkEMR_Care.DataAccess.Repository.ProviderRepository;

namespace ThinkEMR_Care.DataAccess
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProviderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateProviderAsync(Provider provider)
        {
            provider.ProviderGroupId = 2;
            _dbContext.Add(provider);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Provider>> GetAllProviderAsync()
        {
            var providers = _dbContext.Providers;
            return await providers.ToListAsync();
        }
    }
}
