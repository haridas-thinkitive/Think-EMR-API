using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.ProviderGroup
{
    [Table("tbl_ProviderGroupPatient")]

    public class ProviderGroupPatient
    {
        [Key]
        public int PatientID { get; set; }

        public string PatientName { get; set; }
        public int ContactNumber { get; set; }
        public int DOB { get; set; }
        public int LastVisit { get; set; }
        public bool Status { get; set; }

        [ForeignKey("ProviderID")]
        public int ProviderID { get; set; }
        public virtual Provider Provider { get; set; }

        [ForeignKey("ProvidersGroupLocationID")]
        public int ProviderGroupLocationID { get; set; }
        public virtual ProviderGroupLocation ProviderGroupLocations { get; set; }
    }
}
