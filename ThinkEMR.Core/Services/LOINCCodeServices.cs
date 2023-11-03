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
    public class LOINCCodeServices : ILOINCCodeServices
    {
        private readonly ILOINCCodeRepository _LOINCCodeRepository;

        public LOINCCodeServices(ILOINCCodeRepository LOINCCode)
        {
            _LOINCCodeRepository = LOINCCode;
        }

        public async Task<List<LOINCCodeCatalog>> GetAllLOINC()
        {
            return await _LOINCCodeRepository.GetAllLOINC();
        }
        public async Task<LOINCCodeCatalog> CreateLOINCCodeCatalog(LOINCCodeCatalog loincCodeCatalog)
        {
            return await _LOINCCodeRepository.CreateLOINCCodeCatalog(loincCodeCatalog);
        }
    }
}
