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
    public class CPCTCodeCatalogServices : ICPCTCodeCatalog
    {
        private readonly ICPCTCodeCatalogRepository _ICPCTCodeRepository;

        public CPCTCodeCatalogServices(ICPCTCodeCatalogRepository ICPCTCodeRepository)
        {
            _ICPCTCodeRepository = ICPCTCodeRepository;
        }

        public async Task<List<CPTCodeCatalog>> GetAllCPCTCodeCatalog()
        {
            return await _ICPCTCodeRepository.GetAllCPCTCodeCatalog();
        }
        public async Task<CPTCodeCatalog> CreateCPCTCodeCatalog(CPTCodeCatalog cptCodeCatalog)
        {
            return await _ICPCTCodeRepository.CreateCPCTCodeCatalog(cptCodeCatalog);
        }
    }
}
