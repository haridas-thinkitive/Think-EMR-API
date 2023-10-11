using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Data;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Repository.IRepository.IDeveloperDetailsRepository;

namespace ThinkEMR_Care.DataAccess.Repository.RepositoryServices.DeveloperDetailsRepository
{
    public class DeveloperDetailsRepository : IDeveloperDetailsRepository
    {
        private readonly ApplicationDbContext _Context;
        public DeveloperDetailsRepository(ApplicationDbContext context)
        {
            _Context = context;
        }
        public async Task<List<Collaborator>> GetAllDeveloper()
        {
            try
            {
                return await _Context.collaborators.ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
