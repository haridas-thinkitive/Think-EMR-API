using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.Authentication.CustomData
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Name is Required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string? LastName { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool Status { get; set; }
        public string? Role { get; set; }
        public bool IsDeleted { get; set; }
        public byte[]? ProfileImage { get; set; }
    }

}
