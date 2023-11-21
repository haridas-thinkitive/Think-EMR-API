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
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;

        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<StaffUser>> GetStaffUsers()
        {
            try
            {
                return await _context.StaffUsers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<StaffUser> AddStaffUsers(StaffUser staffUser)
        {
            try
            {
                _context.StaffUsers.Add(staffUser);
                await _context.SaveChangesAsync();
                return staffUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<StaffUser> GetStaffUsersById(int id)
        {
            try
            {
                var staffuser = await _context.StaffUsers.Where(d => d.Id == id).FirstOrDefaultAsync();
                if (staffuser != null)
                {
                    return staffuser;
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

        public async Task<StaffUser> EditStaffUsers(int id, StaffUser staffUser)
        {
            try
            {
                if (staffUser == null || staffUser.Id != id)
                {
                    return null;
                }

                var existingStaffUser = await _context.StaffUsers.FirstOrDefaultAsync(x => x.Id == id);

                if (existingStaffUser == null)
                {
                    return null;
                }
                _context.Entry(existingStaffUser).CurrentValues.SetValues(staffUser);
                await _context.SaveChangesAsync();
                
                return staffUser;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<StaffUser> DeleteStaffUsers(int id)
        {
            try
            {
                var result = await _context.StaffUsers.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.StaffUsers.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<ProviderUser>> GetProviderUsers()
        {
            try
            {
                return await _context.ProviderUsers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ProviderUser> AddProviderUsers(ProviderUser providerUser)
        {
            try
            {
                _context.ProviderUsers.Add(providerUser);
                await _context.SaveChangesAsync();
                return providerUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
