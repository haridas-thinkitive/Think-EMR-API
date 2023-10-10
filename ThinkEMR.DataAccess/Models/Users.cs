using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ThinkEMR_Care.DataAccess.Models
{
    public class Users
    {
        public StaffUser StaffUser { get; set; }
        public ProviderUser ProviderUser { get; set; }
    }
    public class StaffUser
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public List<Role> Role { get; set; }
    }
    public class Role
    {
        public string FacilityAdmin { get; set; }
        public string Specialist { get; set; }
        public string PrimaryCareProvider { get; set; }
        public string PhysicianAssistant { get; set; }
        public string Physician { get; set; }
    }
    public class ProviderUser
    {
        [Key]
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public ProviderType ProviderType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProviderPhoneNumber { get; set; }
        public List<LicensedState> LicensedState { get; set; }
        public YearOfExperience YearOfExperience { get; set; }
        public string EmailID { get; set; }
        public SpecialityType SelectSpeciality { get; set; }
        public Gender Gender { get; set; }
        public int OfficeFaxNumber { get; set; }
        public string LicensedNumber { get; set; }
        public string TaxonomyNumber { get; set; }
        public string NPINumber { get; set; }
        public string GroupNPINumber { get; set; }
        //public InsuranceAccepted InsurancesAccepted { get; set; }
        //public WorkLocations WorkLocations { get; set; }
    }
    public class ProviderType
    {
        public string MD { get; set; }
        public string PA { get; set; }
        public string PSYD { get; set; }
        public string LCSW { get; set; }
        public string NP { get; set; }
    }
    public class LicensedState
    {
        public string Alaska { get; set; }
        public string ArmedForceAfrica { get; set; }
        public string Alabama { get; set; }
        public string ArmedForceAmericans { get; set; }
        public string Arkansas { get; set; }
    }
    public class YearOfExperience
    {
        public string Under10Years { get; set; }
        public string From10To20Years { get; set; }
        public string From20To30Years { get; set; }
    }
    public class Gender
    {
        public string Male { get; set; }
        public string Female { get; set; }
        public string Other { get; set; }
    }
    public class BasicAccountProfileData
    {
        public string AreaOfFocus { get; set; }
        public string ProviderEmploymentReferralNumber { get; set; }
        public string HospitalAffilation { get; set; }
        public bool AcceptNewPatients { get; set; }
        public bool AcceptCashPay { get; set; }
        public AgeGroupSeen AgeGroupSeen { get; set; }
        public LanguageSpoken LanguageSpoken { get; set; }
        public InsuaranceVerification InsuaranceVerification { get; set; }  
        public string ProviderBio { get; set; }
        public string ExpertiesIn { get; set; }

        [JsonProperty("Education, Work Experience")]
        public string EducationWorkExperience { get; set; }


    }
    public class AgeGroupSeen
    {
        public string Pediatric { get; set; }
        public string Adult { get; set; }
        public string Geriatric { get; set; }
    }
    public class LanguageSpoken
    {
        public string English { get; set; }
        public string Spanish { get; set; }
        public string Afar { get; set; }
    }
    public class InsuaranceVerification
    {
        public string EmailMeProgramInfo { get; set;}
        public string YesEnrollMe { get; set;}
        public string NoDontEnrollMe { get; set;}
    }
}
