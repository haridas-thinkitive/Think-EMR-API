using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.Core.Services.Interface;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Repository.Interface;

namespace ThinkEMR_Care.Core.Services
{
    public class DashboardDetailsServices :IDashboardDetails
    {
        private readonly IDashboardDetailsCount _dashboardDetail;

        public DashboardDetailsServices(IDashboardDetailsCount dashboardDetails)
        {
            _dashboardDetail = dashboardDetails;
        }

        public async Task<DashboardCount> GetLatestDashboardCount()
        {
            return await _dashboardDetail.GetLatestDashboardCount();
        }

        public async Task<List<DashboardData>> DashboardDetails()
        {
            return await _dashboardDetail.DashboardDetails();
        }

    }
}
