using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models
{
    public class PasswordResetResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Otp { get; set; } = null!;
    }
}
