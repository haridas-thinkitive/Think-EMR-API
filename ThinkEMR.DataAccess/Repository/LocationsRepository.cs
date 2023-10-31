using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Data;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.DataAccess.Repository
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Locations>> GetLocations()
        {
            try
            {
                return await _context.Locations.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Locations> AddLocations(Locations locations)
        {
            try
            {
                _context.Locations.Add(locations);
                await _context.SaveChangesAsync();
                return locations;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Locations> GetLocationsById(int id)
        {
            try
            {
                var location = await _context.Locations.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (location != null)
                {
                    return location;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Locations> EditLocations(int id, Locations location)
        {
            try
            {
                var existingLocation = await _context.Locations.FindAsync(id);
                if (existingLocation == null)
                {
                    return null; 
                }
                _context.Entry(existingLocation).State = EntityState.Detached;

                if (location.Id != id)
                {
                    return null;
                }
                _context.Attach(location);
                _context.Entry(location).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return location;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Locations> DeleteLocations(int id)
        {
            try
            {
                var result = await _context.Locations.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.Locations.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
