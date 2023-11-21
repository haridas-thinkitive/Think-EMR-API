using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models
{
    public class ChangeUserPassword
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConformNewPassword { get; set; }
    }
}
