using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.Core.Services.Interface
{
    public class DrugCatalogServices : IDrugCatalogServices
    {
        private readonly IDrugCatalogRepository _DrugCatalogRepository;


        public DrugCatalogServices(IDrugCatalogRepository DrugCatalogRepository)
        {
            _DrugCatalogRepository = DrugCatalogRepository;
        }

        public async Task<List<DrugCatalog>> GetAllDrugCatalog()
        {
            return await _DrugCatalogRepository.GetAllDrugCatalog();
        }
        public async Task<DrugCatalog> CreateDrugCatalog(DrugCatalog drugCatalog)
        {
            return await _DrugCatalogRepository.CreateDrugCatalog(drugCatalog);
        }
        public async Task<DrugCatalog> UpdateDrugCatalog(DrugCatalog drugCatalog)
        {
            return await _DrugCatalogRepository.UpdateDrugCatalog(drugCatalog);
        }

        public async Task<DrugCatalog> FindById(int id)
        {
            return await _DrugCatalogRepository.FindById(id);
        }
    }
}
