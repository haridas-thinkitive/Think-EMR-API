using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models
{
    public class ProviderGroupProfile
    {
        [Key]
        public int Id { get; set; }
        public string ProviderGroupName { get; set; }
        public string ContactNumber { get; set; }
        public string GroupNPINumber { get; set; }
        public string Website { get; set; }
        public string Information { get; set; }
        public List<SpecialityType> SpecialityType { get; set; }
        public string EmailId { get; set; }
        public string FaxId { get; set; }
        public PhysicalAddress PhysicalAddress { get; set; }
        public BillingAddress BillingAddress { get; set;}
        public WorkingHours PracticeOfficeHours { get; set; }

    }
}
