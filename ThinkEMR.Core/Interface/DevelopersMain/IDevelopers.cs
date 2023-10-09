using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.Core.Interface.DevelopersMain
{
    public interface IDevelopers
    {
        Task<List<Collaborator>> getAllCollaborators();

    }
}
