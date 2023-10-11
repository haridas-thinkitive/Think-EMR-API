using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models
{
    public class AdminProfile
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string UserType { get; set; }
        public string Role { get; set; }

    }
}
