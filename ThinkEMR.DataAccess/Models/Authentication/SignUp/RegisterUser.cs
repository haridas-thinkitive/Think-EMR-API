using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.Authentication.SignUp
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "User Name Requried")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email Requried")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password  Requried")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Name Requried")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "User LastName Requried")]
        public string? LastName { get; set; }
        public string? ContactNumber { get; set; }
        public DateTime LastLogin { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public string? ProfileImage { get; set; }
        public string Role { get; set; }
    }
}
