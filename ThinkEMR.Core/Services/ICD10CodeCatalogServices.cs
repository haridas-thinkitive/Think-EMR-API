using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.Core.Services
{
    public class ICD10CodeCatalogServices : IICD10CodeCatalogServices
    {
        private readonly IICD10CodeCatalogRepository _IICD10CodeRepository;

        public ICD10CodeCatalogServices(IICD10CodeCatalogRepository IICD10CodeRepository)
        {
            _IICD10CodeRepository = IICD10CodeRepository;
        }

        public async Task<List<ICD10CodeCatalog>> GetAllICD10CodeCatalog()
        {
            return await _IICD10CodeRepository.GetAllIICD10CodeCatalog();
        }
        public async Task<ICD10CodeCatalog> CreateICD10CodeCatalog(ICD10CodeCatalog icd10CodeCatalog)
        {
            return await _IICD10CodeRepository.CreateICD10CodeCatalog(icd10CodeCatalog);
        }
    }
}
