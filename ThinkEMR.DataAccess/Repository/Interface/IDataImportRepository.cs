using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;

namespace ThinkEMR_Care.DataAccess.Repository.Interface
{
    public interface IDataImportRepository
    {
        Task<List<DataImport>> GetAllDataImport();
        Task<DataImport> CreateDataImport(DataImport dataImport);
    }
}
