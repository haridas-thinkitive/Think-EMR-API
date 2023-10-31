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
    public class ICD10CodeCatalogRepository : IICD10CodeCatalogRepository
    {
        private readonly ApplicationDbContext _context;
        public ICD10CodeCatalogRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ICD10CodeCatalog>> GetAllIICD10CodeCatalog()
        {
            return await _context.ICD10CodeCatalogs.ToListAsync();
        }
        public async Task<ICD10CodeCatalog> CreateICD10CodeCatalog(ICD10CodeCatalog icd10CodeCatalog)
        {
            _context.ICD10CodeCatalogs.Add(icd10CodeCatalog);
            await _context.SaveChangesAsync();
            return icd10CodeCatalog;
        }
    }
}
