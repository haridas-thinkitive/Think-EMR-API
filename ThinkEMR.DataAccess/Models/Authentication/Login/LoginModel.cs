using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.Authentication.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name Requried")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password Requried")]
        public string? Password { get; set; }
    }
}
