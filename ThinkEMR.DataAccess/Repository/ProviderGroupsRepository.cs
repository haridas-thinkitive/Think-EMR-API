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
    public class ProviderGroupsRepository : IProviderGroupsRepository
    {
        private readonly ApplicationDbContext _context;
        public ProviderGroupsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProviderGroupProfile>> GetProviderGroups()
        {
            var providerGroupProfile = await _context.providerGroupProfiles
                    .Include(p => p.PhysicalAddress)
                    .Include(p => p.BillingAddress)
                    .Include(p => p.PracticeOfficeHours)
                    .ToListAsync();
            try
            {
                return providerGroupProfile.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ProviderGroupProfile> AddProviderGroups(ProviderGroupProfile providerGroupProfile)
        {
            try
            {
                if (providerGroupProfile != null)
                {
                    var result = new ProviderGroupProfile
                    {
                        Id = providerGroupProfile.Id,
                        Image = providerGroupProfile.Image,
                        ProviderGroupName = providerGroupProfile.ProviderGroupName,
                        ContactNumber = providerGroupProfile.ContactNumber,
                        GroupNPINumber = providerGroupProfile.GroupNPINumber,
                        Website = providerGroupProfile.Website,
                        Information = providerGroupProfile.Information,
                        SpecialityTypes = providerGroupProfile.SpecialityTypes, 
                        EmailId = providerGroupProfile.EmailId,
                        FaxId = providerGroupProfile.FaxId,
                        PhysicalAddressId = providerGroupProfile.PhysicalAddressId,
                        PhysicalAddress = new PhysicalAddress
                        {
                            Id = providerGroupProfile.PhysicalAddress.Id,
                            Address1 = providerGroupProfile.PhysicalAddress.Address1,
                            Address2 = providerGroupProfile.PhysicalAddress.Address2,
                            City = providerGroupProfile.PhysicalAddress.City,
                            State = providerGroupProfile.PhysicalAddress.State,
                            Country = providerGroupProfile.PhysicalAddress.Country,
                            ZipCode = providerGroupProfile.PhysicalAddress.ZipCode
                        },
                        BillingAddress = new BillingAddress
                        {
                            Id = providerGroupProfile.BillingAddress.Id,
                            Address1 = providerGroupProfile.BillingAddress.Address1,
                            Address2 = providerGroupProfile.BillingAddress.Address2,
                            City = providerGroupProfile.BillingAddress.City,
                            State = providerGroupProfile.BillingAddress.State,
                            Country = providerGroupProfile.BillingAddress.Country,
                            ZipCode = providerGroupProfile.BillingAddress.ZipCode,
                            SameAsPhysicalAddress = providerGroupProfile.BillingAddress.SameAsPhysicalAddress
                        },
                        PracticeOfficeHours = new PracticeOfficeHours
                        {
                            Monday  = providerGroupProfile.PracticeOfficeHours.Monday,
                            Tuesday  = providerGroupProfile.PracticeOfficeHours.Tuesday,
                            Wednesday  = providerGroupProfile.PracticeOfficeHours.Wednesday,
                            Thursday  = providerGroupProfile.PracticeOfficeHours.Thursday,
                            Friday  = providerGroupProfile.PracticeOfficeHours.Friday,
                            Saturday  = providerGroupProfile.PracticeOfficeHours.Saturday,
                            Sunday  = providerGroupProfile.PracticeOfficeHours.Sunday,
                        },
                        CreatedDate = providerGroupProfile.CreatedDate,
                        UpdatedDate = providerGroupProfile.UpdatedDate
                    };
                    providerGroupProfile = result;
                }
                _context.providerGroupProfiles.Add(providerGroupProfile);
                await _context.SaveChangesAsync();
                return providerGroupProfile;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ProviderGroupProfile> GetProviderGroupsById(int id)
        {
            try
            {
                var providerGroup = await _context.providerGroupProfiles
                    .Include(p => p.PhysicalAddress)
                    .Include(p => p.BillingAddress)
                    .Include(p => p.PracticeOfficeHours)
                    .FirstOrDefaultAsync(p => p.Id == id);
                //var providerGroup = await _context.providerGroupProfiles.Where(p => p.Id == id).FirstOrDefaultAsync();

                if (providerGroup != null)
                {
                    return providerGroup;
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


        public async Task<ProviderGroupProfile> EditProviderGroups(int id, ProviderGroupProfile updatedProviderGroupProfile)
        {
            try
            {
                //var existingProviderGroupProfile = await _context.providerGroupProfiles.FindAsync(id);

                var existingProviderGroupProfile = await _context.providerGroupProfiles
                    .Include(p => p.PhysicalAddress)
                    .Include(p => p.BillingAddress)
                    .Include(p => p.PracticeOfficeHours)
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                if (existingProviderGroupProfile != null)
                {
                    // Update the properties of the existing ProviderGroupProfile with the values from the updated model
                    existingProviderGroupProfile.Image = updatedProviderGroupProfile.Image;
                    existingProviderGroupProfile.ProviderGroupName = updatedProviderGroupProfile.ProviderGroupName;
                    existingProviderGroupProfile.ContactNumber = updatedProviderGroupProfile.ContactNumber;
                    existingProviderGroupProfile.GroupNPINumber = updatedProviderGroupProfile.GroupNPINumber;
                    existingProviderGroupProfile.Website = updatedProviderGroupProfile.Website;
                    existingProviderGroupProfile.Information = updatedProviderGroupProfile.Information;
                    existingProviderGroupProfile.SpecialityTypes = updatedProviderGroupProfile.SpecialityTypes;
                    existingProviderGroupProfile.EmailId = updatedProviderGroupProfile.EmailId;
                    existingProviderGroupProfile.FaxId = updatedProviderGroupProfile.FaxId;

                    if (existingProviderGroupProfile.PhysicalAddress != null)
                    {
                        // Update PhysicalAddress
                        existingProviderGroupProfile.PhysicalAddress.Address1 = updatedProviderGroupProfile.PhysicalAddress.Address1;
                        existingProviderGroupProfile.PhysicalAddress.Address2 = updatedProviderGroupProfile.PhysicalAddress.Address2;
                        existingProviderGroupProfile.PhysicalAddress.City = updatedProviderGroupProfile.PhysicalAddress.City;
                        existingProviderGroupProfile.PhysicalAddress.State = updatedProviderGroupProfile.PhysicalAddress.State;
                        existingProviderGroupProfile.PhysicalAddress.Country = updatedProviderGroupProfile.PhysicalAddress.Country;
                        existingProviderGroupProfile.PhysicalAddress.ZipCode = updatedProviderGroupProfile.PhysicalAddress.ZipCode;

                    }

                    if (existingProviderGroupProfile.BillingAddress != null)
                    {
                        // Update BillingAddress
                        existingProviderGroupProfile.BillingAddress.Address1 = updatedProviderGroupProfile.BillingAddress.Address1;
                        existingProviderGroupProfile.BillingAddress.Address2 = updatedProviderGroupProfile.BillingAddress.Address2;
                        existingProviderGroupProfile.BillingAddress.City = updatedProviderGroupProfile.BillingAddress.City;
                        existingProviderGroupProfile.BillingAddress.State = updatedProviderGroupProfile.BillingAddress.State;
                        existingProviderGroupProfile.BillingAddress.Country = updatedProviderGroupProfile.BillingAddress.Country;
                        existingProviderGroupProfile.BillingAddress.ZipCode = updatedProviderGroupProfile.BillingAddress.ZipCode;
                        existingProviderGroupProfile.BillingAddress.SameAsPhysicalAddress = updatedProviderGroupProfile.BillingAddress.SameAsPhysicalAddress;

                    }

                    if (existingProviderGroupProfile.PracticeOfficeHours != null && updatedProviderGroupProfile.PracticeOfficeHours != null)
                    {
                        // Update PracticeOfficeHours
                        existingProviderGroupProfile.PracticeOfficeHours.Monday = updatedProviderGroupProfile.PracticeOfficeHours.Monday;
                        existingProviderGroupProfile.PracticeOfficeHours.Tuesday = updatedProviderGroupProfile.PracticeOfficeHours.Tuesday;
                        existingProviderGroupProfile.PracticeOfficeHours.Wednesday = updatedProviderGroupProfile.PracticeOfficeHours.Wednesday;
                        existingProviderGroupProfile.PracticeOfficeHours.Thursday = updatedProviderGroupProfile.PracticeOfficeHours.Thursday;
                        existingProviderGroupProfile.PracticeOfficeHours.Friday = updatedProviderGroupProfile.PracticeOfficeHours.Friday;
                        existingProviderGroupProfile.PracticeOfficeHours.Saturday = updatedProviderGroupProfile.PracticeOfficeHours.Saturday;
                        existingProviderGroupProfile.PracticeOfficeHours.Sunday = updatedProviderGroupProfile.PracticeOfficeHours.Sunday;

                    }

                    existingProviderGroupProfile.UpdatedDate = DateTime.Now;

                    await _context.SaveChangesAsync();
                }

                return updatedProviderGroupProfile;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<ProviderGroupProfile> DeleteProviderGroups(int id)
        {
            try
            {
                var result = await _context.providerGroupProfiles.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.providerGroupProfiles.Remove(result);

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
