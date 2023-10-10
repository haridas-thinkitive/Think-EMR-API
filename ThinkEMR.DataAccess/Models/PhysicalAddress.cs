﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models
{
    public class PhysicalAddress
    {
        [Key]
        public int Id { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public List<State> State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }

    public class State
    {
        public string AllState { get; set; }
        public string Alaska { get; set; }
        public string California { get; set; }
        public string Colorado { get; set; }
        public string Florida { get; set; }
    }
}