using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.ProviderGroup
{
    [Table("tbl_ProviderGroupBillingAddress")]
    public class ProviderGroupBillingAddress
    {
        [Key]
        public int ProviderGroupBillingAddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }

        [ForeignKey("ProviderGroupId")]
        public int ProviderGroupId { get; set;}
        public ProviderGroup ProviderGroup { get; set; }
    }
}
