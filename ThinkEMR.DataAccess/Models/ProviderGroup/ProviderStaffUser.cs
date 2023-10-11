using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.ProviderGroup
{
    [Table("tbl_ProviderStaffUser")]

    public class ProviderStaffUser
    {
        [Key]
        public int StaffUserId { get; set; }

        [ForeignKey("ProviderGroupId")]
        public int ProviderGroupId { get; set; }
        public ProviderGroup ProviderGroup { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public string EmailId { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        public bool IsActive { get; set; }
    }

}

