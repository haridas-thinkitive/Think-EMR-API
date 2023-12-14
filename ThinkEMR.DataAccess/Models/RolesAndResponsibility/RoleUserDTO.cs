using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.RolesAndResponsibility
{
    public class RoleUserDTO
    {
        public string RoleName { get; set; }
        public int RoleType { get; set; }
        public List<int> SelectedPermissions { get; set; }
    }
}
