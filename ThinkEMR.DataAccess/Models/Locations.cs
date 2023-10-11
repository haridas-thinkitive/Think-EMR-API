using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models
{
    public class Locations
    {
        [Key]
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string LocationName { get; set; }
        public int LocationId { get; set; }
        public List<SpecialityType> SpecialityType { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public string FaxId { get; set; }
        public string Information { get; set; }

    }

    public class SpecialityType
    {
        public string Multispeciality { get; set; }
        public string Physiotherapist { get; set; }
        public string Dentist { get; set; }
        public string Orthopedist { get; set; }
        public string Acupuncturist { get; set; }
    }
}
