using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.ProviderGroup
{
    [Table("tbl_ProviderGroupLocation")]
    public class ProviderGroupLocation
    {
        [Key] 
        public int ProviderGroupLocationId { get; set; }

        [ForeignKey("ProviderGroupId")]
        public int ProviderGroupId { get; set; }
        public ProviderGroup ProviderGroup { get; set; }

        public string LocationName { get; set; }    
        public ProviderGroupLocationSpeciality Speciality { get; set; }
        public bool Status { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public string FaxId { get; set; }
        public string Information { get; set; }
        
    }
    public enum ProviderGroupLocationSpeciality
    {
        Multi_speciality,
        Physiotherapist,
        Dentist,
        Orthopedist,
        Acupuncturist,
    }
}
