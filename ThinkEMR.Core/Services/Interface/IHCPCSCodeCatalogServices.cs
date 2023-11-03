using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;

namespace ThinkEMR_Care.Core.Services.Interface
{
    public interface IHCPCSCodeCatalogServices
    {
        Task<List<HCPCSCodeCatalog>> GetAllHCPCSCodeCatalog();
        Task<HCPCSCodeCatalog> CreateHCPCSCodeCatalog(HCPCSCodeCatalog hcpcsCodeCatalog);
    }
}
