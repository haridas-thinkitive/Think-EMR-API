using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models
{
    public class DashboardCount
    {
        [Key]
        public int Id { get; set; }
        public int ProviderGroupCount { get; set; }
        public int ProvidersCount { get; set; }
        public int PatientsCount { get; set; }
        public int AppointmentsCount { get; set; }
        public int EncountersCount { get; set; }
    }
}
