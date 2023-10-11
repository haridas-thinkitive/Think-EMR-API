using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.ProviderGroup
{
    [Table("tbl_ProviderGroup")]
    public class ProviderGroup
    {
        [Key]
        public int ProviderGroupId { get; set; }
        public string ProviderGroupName { get; set; }
        public string Speciality { get; set; }
        public string ContactNo { get; set; }
        public string Website { get; set; }
        public bool Status { get; set; }
        public string State { get; set; }
        public string FaxId { get; set; }
        public string ProviderGroupEmailId { get; set; }
        public string Description { get; set; }
                
        public ICollection<Provider> Providers { get; set; }
        public ICollection<ProviderDepartment> ProviderDepartments { get; set; }
        public ICollection<ProviderStaffUser> ProviderStaffUsers { get; set; }
        public ICollection<ProviderGroupLocation> ProviderGroupLocations { get; set; }

    }
}
