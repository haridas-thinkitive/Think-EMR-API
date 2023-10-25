using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.Authentication.SignUp
{
    public class ResetPassword
    {
        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password And Conformation Password dosenot match")]
        public string ConfirmPassword { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Token { get; set; } = null!;

    }
}
