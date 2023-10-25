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
            try
            {
                return await _context.providerGroupProfiles.ToListAsync();
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
                var providerGroup = await _context.providerGroupProfiles.Where(p => p.Id == id).FirstOrDefaultAsync();
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

        public async Task<ProviderGroupProfile> EditProviderGroups(int id, ProviderGroupProfile providerGroupProfile)
        {
            try
            {
                var existingProviderGroup = await _context.providerGroupProfiles.FindAsync(id);

                if (existingProviderGroup == null)
                {
                    return null;
                }
                _context.Entry(existingProviderGroup).State = EntityState.Detached;

                if (id != providerGroupProfile.Id)
                {
                    return null;
                }
                _context.Attach(providerGroupProfile);
                _context.Entry(providerGroupProfile).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return providerGroupProfile;
            }
            catch (Exception ex)
            {
                return null;
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
