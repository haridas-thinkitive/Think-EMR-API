using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.Core.Services.IServices.IDeveloperInformationServices
{
    public interface IDeveloperInfoService
    {
        Task<List<Collaborator>> GetAllDeveloper();
    }
}
