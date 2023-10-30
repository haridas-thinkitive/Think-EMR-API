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
    public class HCPCSCodeCatalogRepository : IHCPCSCodeCatalogRepository
    {
        private readonly ApplicationDbContext _context;
        public HCPCSCodeCatalogRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<HCPCSCodeCatalog>> GetAllHCPCSCodeCatalog()
        {
            return await _context.hPCSCodeCatalogs.ToListAsync();
        }
        public async Task<HCPCSCodeCatalog> CreateHCPCSCodeCatalog(HCPCSCodeCatalog hcpcsCodeCatalog)
        {
            _context.hPCSCodeCatalogs.Add(hcpcsCodeCatalog);
            await _context.SaveChangesAsync();
            return hcpcsCodeCatalog;
        }
    }
}
