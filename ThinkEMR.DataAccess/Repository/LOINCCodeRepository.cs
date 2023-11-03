using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Data;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.DataAccess.Repository
{
    public class LOINCCodeRepository : ILOINCCodeRepository
    {
        private readonly ApplicationDbContext _context;
        public LOINCCodeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<LOINCCodeCatalog>> GetAllLOINC()
        {
            return await _context.LOINCCodeCatalogs.ToListAsync();
        }
        public async Task<LOINCCodeCatalog> CreateLOINCCodeCatalog(LOINCCodeCatalog loincCodeCatalog)
        {
            _context.LOINCCodeCatalogs.Add(loincCodeCatalog);
            await _context.SaveChangesAsync();
            return loincCodeCatalog;
        }
    }
}
