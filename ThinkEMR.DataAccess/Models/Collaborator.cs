using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models
{
    public class Collaborator
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }

        public string Description { get; set; }

        public string BranchName { get; set; }
    }
}
