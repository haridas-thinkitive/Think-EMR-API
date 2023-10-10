using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.DataAccess.Repository.IRepository.IDeveloperDetailsRepository
{
    public interface IDeveloperDetailsRepository
    {
        Task<List<Collaborator>> GetAllDeveloper();
    }
}
