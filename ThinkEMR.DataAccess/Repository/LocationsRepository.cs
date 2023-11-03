using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Data;
using ThinkEMR_Care.DataAccess.Migrations;
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
            var location = await _context.locations
                    .Include(p => p.PhysicalAddress)
                    .Include(p => p.BillingAddress)
                    .Include(p => p.PracticeOfficeHours)
                    .ToListAsync();
            try
            {
                return location.ToList();
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
                _context.locations.Add(locations);
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
                //var location = await _context.locations.Where(p => p.Id == id).FirstOrDefaultAsync();
                var location = await _context.locations
                    .Include(p => p.PhysicalAddress)
                    .Include(p => p.BillingAddress)
                    .Include(p => p.PracticeOfficeHours)
                    .FirstOrDefaultAsync(p => p.Id == id);

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

        public async Task<Locations> EditLocations(int id, Locations updatedLocation)
        {
            try
            {
                var existingLocation = await _context.locations
                    .Include(p => p.PhysicalAddress)
                    .Include(p => p.BillingAddress)
                    .Include(p => p.PracticeOfficeHours)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (existingLocation == null)
                {
                    return null;
                }

                existingLocation.AddLocationLogo = updatedLocation.AddLocationLogo;
                existingLocation.LocationName = updatedLocation.LocationName;
                existingLocation.LocationId = updatedLocation.LocationId;
                existingLocation.SpecialityType = updatedLocation.SpecialityType;
                existingLocation.ContactNumber = updatedLocation.ContactNumber;
                existingLocation.EmailId = updatedLocation.EmailId;
                existingLocation.FaxId = updatedLocation.FaxId;
                existingLocation.Information = updatedLocation.Information;

                if (existingLocation.PhysicalAddress != null)
                {
                    existingLocation.PhysicalAddress.Address1 = updatedLocation.PhysicalAddress.Address1;
                    existingLocation.PhysicalAddress.Address2 = updatedLocation.PhysicalAddress.Address2;
                    existingLocation.PhysicalAddress.City = updatedLocation.PhysicalAddress.City;
                    existingLocation.PhysicalAddress.State = updatedLocation.PhysicalAddress.State;
                    existingLocation.PhysicalAddress.Country = updatedLocation.PhysicalAddress.Country;
                    existingLocation.PhysicalAddress.ZipCode = updatedLocation.PhysicalAddress.ZipCode;
                }

                if (existingLocation.BillingAddress != null)
                {
                    existingLocation.BillingAddress.Address1 = updatedLocation.BillingAddress.Address1;
                    existingLocation.BillingAddress.Address2 = updatedLocation.BillingAddress.Address2;
                    existingLocation.BillingAddress.City = updatedLocation.BillingAddress.City;
                    existingLocation.BillingAddress.State = updatedLocation.BillingAddress.State;
                    existingLocation.BillingAddress.Country = updatedLocation.BillingAddress.Country;
                    existingLocation.BillingAddress.ZipCode = updatedLocation.BillingAddress.ZipCode;
                    existingLocation.BillingAddress.SameAsPhysicalAddress = updatedLocation.BillingAddress.SameAsPhysicalAddress;
                }

                if (existingLocation.PracticeOfficeHours != null && updatedLocation.PracticeOfficeHours != null)
                {
                    existingLocation.PracticeOfficeHours.Monday = updatedLocation.PracticeOfficeHours.Monday;
                    existingLocation.PracticeOfficeHours.Tuesday = updatedLocation.PracticeOfficeHours.Tuesday;
                    existingLocation.PracticeOfficeHours.Wednesday = updatedLocation.PracticeOfficeHours.Wednesday;
                    existingLocation.PracticeOfficeHours.Thursday = updatedLocation.PracticeOfficeHours.Thursday;
                    existingLocation.PracticeOfficeHours.Friday = updatedLocation.PracticeOfficeHours.Friday;
                    existingLocation.PracticeOfficeHours.Saturday = updatedLocation.PracticeOfficeHours.Saturday;
                    existingLocation.PracticeOfficeHours.Sunday = updatedLocation.PracticeOfficeHours.Sunday;
                }

                existingLocation.Status = true;

                await _context.SaveChangesAsync();

                return existingLocation;

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
                var result = await _context.locations.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.locations.Remove(result);
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
