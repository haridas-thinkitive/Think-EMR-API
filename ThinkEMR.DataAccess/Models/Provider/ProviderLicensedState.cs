using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.Provider
{
    public class ProviderLicensedState
    {
        [Key]
        public int ProviderLicensedStateId { get; set; }
        public string ProviderLicensedStateName { get; set; }
    }
}
