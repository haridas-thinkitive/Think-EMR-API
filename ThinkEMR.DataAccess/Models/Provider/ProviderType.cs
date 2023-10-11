using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.Provider
{
    public class ProviderType
    {
        [Key]
        public int ProviderTypeId { get; set; }
        public string ProviderTypeName { get; set; }
    }
}
