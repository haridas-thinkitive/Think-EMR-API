using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentAdmin { get; set; }
        public string ContactNumber { get; set; }
        public bool Status { get; set; }

    }
}
