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
    public class DataImportRepository : IDataImportRepository
    {
        private readonly ApplicationDbContext _context;
        public DataImportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DataImport>> GetAllDataImport()
        {
            return await _context.DataImports.ToListAsync();
        }
        public async Task<DataImport> CreateDataImport(DataImport dataImport)
        {
            _context.DataImports.Add(dataImport);
            await _context.SaveChangesAsync();
            return dataImport;
        }
    }
}
