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
    public class DataImportServices : IDataImportServices
    {
        private readonly IDataImportRepository _DataImportRepository;

        public DataImportServices(IDataImportRepository DataImportRepository)
        {
            _DataImportRepository = DataImportRepository;
        }

        public async Task<List<DataImport>> GetAllDataImport()
        {
            return await _DataImportRepository.GetAllDataImport();
        }
        public async Task<DataImport> CreateDataImport(DataImport dataImport)
        {
            return await _DataImportRepository.CreateDataImport(dataImport);
        }
    }
}
