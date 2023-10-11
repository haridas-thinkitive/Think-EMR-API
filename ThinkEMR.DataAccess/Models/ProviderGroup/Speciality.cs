using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.ProviderGroup
{
    public class Speciality
    {
        [Key]
        public int SpecialityId { get; set; }
        public string SpecialityName { get; set; }
    }
}
