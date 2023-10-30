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
    public class CPCTCodeCatalogRepository : ICPCTCodeCatalogRepository
    {
        private readonly ApplicationDbContext _context;
        public CPCTCodeCatalogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CPTCodeCatalog>> GetAllCPCTCodeCatalog()
        {
            return await _context.cPTCodeCatalogs.ToListAsync();
        }
        public async Task<CPTCodeCatalog> CreateCPCTCodeCatalog(CPTCodeCatalog cptCodeCatalog)
        {
            _context.cPTCodeCatalogs.Add(cptCodeCatalog);
            await _context.SaveChangesAsync();
            return cptCodeCatalog;
        }
    }
}
