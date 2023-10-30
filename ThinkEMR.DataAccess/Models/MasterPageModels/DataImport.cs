using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.MasterPageModels
{
    public class DataImport
    {
        [Key]
        public int Id { get; set; }
        public string Entity { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int TotalRecords { get; set; }
        public string SampleTemplate { get; set; }
        public string UploadFile { get; set; }
    }
}
