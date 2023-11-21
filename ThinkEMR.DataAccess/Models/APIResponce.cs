using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models
{
    public class APIResponce<T>
    {
        public bool IsSuccess { get; set; }

        public string? Message  { get; set; }

        public int StatusCode { get; set; }

        public T? Responce { get; set; }

        public string? CurrentUserNmae { get; set; }

    }
}
