using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderHelper = ThinkEMR_Care.DataAccess.Models.ProviderGroup;
using ThinkEMR_Care.DataAccess.Models.Provider;

namespace ThinkEMR_Care.DataAccess.Models.ProviderGroup
{
    [Table("tbl_Provider")]
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }

        public int RoleId { get; set; } // referred from Roles tables 

        [ForeignKey("ProviderGroupId")]
        public int ProviderGroupId { get; set; }
        public ProviderGroup ProviderGroup { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        [StringLength(20)]
        public string LicenseNumber { get; set; }

        [Required]
        [MaxLength(10)]
        public string ProviderPhoneNumber { get; set; }
        [Required]
        public string OfficeFaxNumber { get; set; }

        [Required]
        public string GroupNPINumber { get; set; }
        [Required]
        public string TaxonomyNumber { get; set; }

        [ForeignKey("ProviderType")]
        public int ProviderTypeId { get; set; }
        public ProviderType ProviderType { get; set; }


        [ForeignKey("SpecialityId")]
        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }

        public ProviderHelper.Gender Gender { get; set; }

        [ForeignKey("ProviderAcceptedInsuranceId")]
        public int ProviderAcceptedInsuranceId { get; set; }
        public ProviderAcceptedInsurance ProviderAcceptedInsurance { get; set; }

        [ForeignKey("ProviderLicensedStateId")]
        public int ProviderLicensedStateId { get; set; }
        public ProviderLicensedState ProviderLicensedState { get; set; }

        [ForeignKey("ProviderWorkLocationId")]
        public int ProviderWorkLocationId { get; set; }
        public ProviderWorkLocation ProviderWorkLocation { get; set; }

        [MaxLength(100)]
        public string Sub_Specialities { get; set; }
        public string Hospital_Affialation { get; set; }
        public ProviderHelper.AgeGroupSeen AgeGroupSeen { get; set; }
        public string Provider_Employment_Referral_Number { get; set; }
        public bool AcceptNewPatients { get; set; }
        public bool AcceptCashPay { get; set; }
        [ForeignKey("ProviderSpokenLanguageId")]
        public int ProviderSpokenLanguageId { get; set; }
        public ProviderSpokenLanguage ProviderSpokenLanguage { get; set; }
        public ProviderHelper.InsuranceVerification InsuranceVerification { get; set; }
        [MaxLength(100)]
        public string ProviderBio { get; set; }
        public string ExpertiseIn { get; set; }
        public string Education_WorkExperience { get; set; }
        public bool Status { get; set; }
    }
}
