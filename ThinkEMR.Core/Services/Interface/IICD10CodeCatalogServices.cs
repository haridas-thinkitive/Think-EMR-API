using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;

namespace ThinkEMR_Care.Core.Services.Interface
{
    public interface IICD10CodeCatalogServices
    {
        Task<List<ICD10CodeCatalog>> GetAllICD10CodeCatalog();
        Task<ICD10CodeCatalog> CreateICD10CodeCatalog(ICD10CodeCatalog icd10CodeCatalog);
    }
}
