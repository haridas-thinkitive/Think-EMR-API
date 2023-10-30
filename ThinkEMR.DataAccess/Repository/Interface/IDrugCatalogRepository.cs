using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;

namespace ThinkEMR_Care.DataAccess.Repository.Interface
{
    public interface IDrugCatalogRepository
    {
        Task<List<DrugCatalog>> GetAllDrugCatalog();
        Task<DrugCatalog> CreateDrugCatalog(DrugCatalog drugCatalog);
        Task<DrugCatalog> UpdateDrugCatalog(DrugCatalog drugCatalog);
        Task<DrugCatalog> FindById(int id);
    }
}
