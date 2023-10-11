using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models.ProviderGroup
{
    [Table("tbl_ProviderHelper")]

    public class ProviderHelper
    {
        public enum Gender
        {
            Male,
            Female,
            Other
        }
        public enum ProviderExperience
        {
            Under_10_Years,
            Between_10_20_Years,
            Between_20_30_Years
        }

        public enum AgeGroupSeen
        {
            Pediatric,
            Adult,
            Geriatric
        }
        public enum InsuranceVerification
        {
            Email_me_program_info,
            Yes_Enroll_me,
            No_Do_Not_Enroll_me
        }
    }
}
