using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.Provider
{
    public class ProviderWorkLocation
    {
        [Key]
        public int ProviderWorkLocationId { get; set; }
        public string ProviderWorkLocationName { get; set; }
    }
}
