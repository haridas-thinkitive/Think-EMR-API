using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Repository;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.Core.Services
{
    public class LocationsService : ILocationsService
    {
        private readonly ILocationsRepository _locationsRepository;
        public LocationsService(ILocationsRepository locationsRepository)
        {
            _locationsRepository = locationsRepository;
        }
        public async Task<List<Locations>> GetLocations()
        {
            return await _locationsRepository.GetLocations();
        }

        public async Task<Locations> AddLocations(Locations locations)
        {
            return await _locationsRepository.AddLocations(locations);
        }

        public async Task<Locations> GetLocationsById(int id)
        {
            return await _locationsRepository.GetLocationsById(id);
        }

        public async Task<Locations> EditLocations(int id, Locations locations)
        {
            return await _locationsRepository.EditLocations(id, locations);
        }

        public async Task<Locations> DeleteLocations(int id)
        {
            return await _locationsRepository.DeleteLocations(id);
        }
    }
}
