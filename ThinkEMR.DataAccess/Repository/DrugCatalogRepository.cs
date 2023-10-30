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
    public class DrugCatalogRepository : IDrugCatalogRepository
    {
        private readonly ApplicationDbContext _context;
        public DrugCatalogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DrugCatalog>> GetAllDrugCatalog()
        {
            return await _context.drugCatalogs.ToListAsync();
        }

        public async Task<DrugCatalog> FindById(int id)
        {
            return await _context.drugCatalogs.FindAsync(id);
        }
        public async Task<DrugCatalog> CreateDrugCatalog(DrugCatalog drugCatalog)
        {
            _context.drugCatalogs.Add(drugCatalog);
            await _context.SaveChangesAsync();
            return drugCatalog;
        }

        public async Task<DrugCatalog> UpdateDrugCatalog(DrugCatalog drugCatalog)
        {
            var existingDrugCatalog = await _context.drugCatalogs.FirstOrDefaultAsync(dc => dc.Id == drugCatalog.Id);

            if (existingDrugCatalog == null)
            {
                return null;
            }

            existingDrugCatalog.Speciality = drugCatalog.Speciality;
            existingDrugCatalog.Type = drugCatalog.Type;
            existingDrugCatalog.Medicine = drugCatalog.Medicine;
            existingDrugCatalog.Dose = drugCatalog.Dose;
            existingDrugCatalog.When = drugCatalog.When;
            existingDrugCatalog.Where = drugCatalog.Where;
            existingDrugCatalog.Frequency = drugCatalog.Frequency;
            existingDrugCatalog.Duration = drugCatalog.Duration;
            existingDrugCatalog.Qty = drugCatalog.Qty;
            existingDrugCatalog.Instructions = drugCatalog.Instructions;
            existingDrugCatalog.Status = drugCatalog.Status;

            await _context.SaveChangesAsync();

            return existingDrugCatalog;
        }
    }
}
