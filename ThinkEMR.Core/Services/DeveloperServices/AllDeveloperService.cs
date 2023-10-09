using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.Core.Data;
using ThinkEMR_Care.Core.Interface.DevelopersMain;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.Core.Services.DeveloperServices
{
    public class AllDeveloperService : IDevelopers
    {
        private readonly ApplicationDbContext _context;

        public AllDeveloperService(ApplicationDbContext context)
        {
            _context = context;   
        }

        public async Task<List<Collaborator>> getAllCollaborators()
        {
            List<Collaborator> result = null;
            try
            {
                result = await _context.collaborators.ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }
    }
}
