using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models
{
    public class BillingAddress : PhysicalAddress
    {
        public bool SameAsPhysicalAddress { get; set; }
    }
}
