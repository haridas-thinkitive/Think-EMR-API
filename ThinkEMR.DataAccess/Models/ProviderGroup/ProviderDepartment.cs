using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.ProviderGroup
{
    [Table("tbl_ProviderDepartment")]
    public class ProviderDepartment
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int DepartmentAdminId { get; set; } //currently have no reference but in future it will be referenced from foreign key
        public string ContactNo { get; set; }

        [ForeignKey("ProviderGroupId")]
        public int ProviderGroupId { get; set; }
        public ProviderGroup providerGroup { get; set; }

    }
}
