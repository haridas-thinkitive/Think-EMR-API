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
    public class DashboardDetailsRepository : IDashboardDetailsCount
    {
        private readonly ApplicationDbContext _Context;
        public DashboardDetailsRepository(ApplicationDbContext applicationDbContext)
        {
            _Context = applicationDbContext;
        }
        public async Task<DashboardCount> GetLatestDashboardCount()
        {
            try
            {
                var result = new DashboardCount
                {
                    // EncountersCount = await _Context.Encounters.CountAsync(),
                    // AppointmentsCount = await _Context.Encounters.CountAsync(),
                    // ProviderGroupCount = await _Context.Encounters.CountAsync(),

                    ProviderGroupCount = 10, //Inject Respective model dependency and use count
                    AppointmentsCount = 15,
                    EncountersCount = 521,
                    PatientsCount = 452,
                    ProvidersCount = 50,
                };
                return await Task.FromResult(result);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public async Task<List<DashboardData>> DashboardDetails()
        {
            var Result = await _Context.DashboardDatas.ToListAsync();
            return Result;

        }

    }
}
