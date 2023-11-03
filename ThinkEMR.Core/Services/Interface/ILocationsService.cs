using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.Core.Services.Interface
{
    public interface ILocationsService
    {
        Task<List<Locations>> GetLocations();

        Task<Locations> AddLocations(Locations locations);

        Task<Locations> GetLocationsById(int id);

        Task<Locations> EditLocations(int id, Locations locations);

        Task<Locations> DeleteLocations(int id);
    }
}
