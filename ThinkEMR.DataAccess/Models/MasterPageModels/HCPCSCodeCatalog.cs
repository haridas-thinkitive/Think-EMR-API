using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.MasterPageModels
{
    public class HCPCSCodeCatalog
    {
        [Key]
        public int Id { get; set; }
        public string HCPCSCode { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
