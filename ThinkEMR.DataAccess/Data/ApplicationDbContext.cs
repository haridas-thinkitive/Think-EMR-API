using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Models.Provider;
using ThinkEMR_Care.DataAccess.Models.ProviderGroup;

namespace ThinkEMR_Care.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedProviderHelperData(builder);
            
        }

        private void SeedProviderHelperData(ModelBuilder builder)
        {
            builder.Entity<ProviderType>().HasData
                (
                new ProviderType() { ProviderTypeName = "MD"},
                new ProviderType() { ProviderTypeName = "PA"},
                new ProviderType() { ProviderTypeName = "PSYD"},
                new ProviderType() { ProviderTypeName = "LCSW"},
                new ProviderType() { ProviderTypeName = "NP"}
                 );
        }


        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderGroup> ProviderGroups { get; set; }
        public DbSet<ProviderStaffUser> StaffUsers { get; set; }
        public DbSet<ProviderDepartment> ProviderDepartments { get; set; }
        public DbSet<ProviderGroupBillingAddress> ProviderGroupBillingAddress { get; set; }
        public DbSet<ProviderGroupLocation> ProviderGroupLocations { get; set; }
        public DbSet<ProviderGroupLocationBillingAddress> ProviderGroupLocationBillingAddress { get; set; }
        public DbSet<ProviderGroupLocationPhysicalAddress> ProviderGroupLocationPhysicalAddress { get; set; }
        public DbSet<ProviderGroupOfficeHour> ProviderGroupOfficeHours { get; set; }
        public DbSet<ProviderGroupPatient> ProviderGroupPatients { get; set; }
        public DbSet<ProviderGroupPhysicalAddress> ProviderGroupPhysicalAddress { get; set; }
        public DbSet<ProviderAcceptedInsurance> ProviderAcceptedInsurances { get; set; }
        public DbSet<ProviderLicensedState> ProviderLicensedStates { get; set; }
        public DbSet<ProviderSpokenLanguage> ProviderSpokenLanguages { get; set; }
        public DbSet<ProviderType> ProviderTypes { get; set; }
        public DbSet<ProviderWorkLocation> ProviderWorkLocations { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
    }
}
