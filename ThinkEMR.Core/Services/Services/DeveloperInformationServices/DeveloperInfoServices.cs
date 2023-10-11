using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.Core.Services.IServices.IDeveloperInformationServices;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Repository;
using ThinkEMR_Care.DataAccess.Repository.IRepository.IDeveloperDetailsRepository;

namespace ThinkEMR_Care.Core.Services.Services.DeveloperInformationServices
{
    public class DeveloperInfoServices : IDeveloperInfoService
    {
        private readonly IDeveloperDetailsRepository _developerRepository;

        public DeveloperInfoServices(IDeveloperDetailsRepository developerDetails)
        {
            _developerRepository = developerDetails;
        }

        public async Task<List<Collaborator>> GetAllDeveloper()
        {
            return await _developerRepository.GetAllDeveloper();
        }
    }
}
