using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.ProviderGroup
{
    [Table("tbl_ProviderGroupOfficeHour")]

    public class ProviderGroupOfficeHour
    {
        [Key]
        public int ProviderGroupOfficeHourId { get; set; }

        [ForeignKey("ProviderGroupId")]
        public int ProviderGroupId { get; set; }
        public ProviderGroup ProviderGroup { get; set; }

        public string Day { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }

    } 
}
