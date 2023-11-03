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
    public class HCPCSCodeCatalogServices : IHCPCSCodeCatalogServices
    {
        private readonly IHCPCSCodeCatalogRepository _IHCPCSCodeRepository;

        public HCPCSCodeCatalogServices(IHCPCSCodeCatalogRepository IHCPCSCodeRepository)
        {
            _IHCPCSCodeRepository = IHCPCSCodeRepository;
        }

        public async Task<List<HCPCSCodeCatalog>> GetAllHCPCSCodeCatalog()
        {
            return await _IHCPCSCodeRepository.GetAllHCPCSCodeCatalog();
        }
        public async Task<HCPCSCodeCatalog> CreateHCPCSCodeCatalog(HCPCSCodeCatalog hcpcsCodeCatalog)
        {
            return await _IHCPCSCodeRepository.CreateHCPCSCodeCatalog(hcpcsCodeCatalog);
        }
    }
}
