using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models.Roles_and_Responsibility;

namespace ThinkEMR_Care.DataAccess.Models.RolesAndResponsibility
{
    public class RoleUser
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleType { get; set; }
        public string Permissions { get; set; }
        public bool IsDeleted { get; set; }
    }
}
