using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
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
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);
            sendRoles(builder);
        }

        private void sendRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin1", NormalizedName = "Admin1", ConcurrencyStamp = "1" },
                new IdentityRole() { Name = "Admin2", NormalizedName = "Admin2", ConcurrencyStamp = "2" }
         );
        }


        public DbSet<Collaborator> collaborators { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<DashboardCount> DashboardCounts { get; set; }

        public DbSet<DashboardData> DashboardDatas { get; set; }
        //public DbSet<ProviderGroup> ProviderGroups { get; set; }
        //public DbSet<ProviderStaffUser> StaffUsers { get; set; }
        //public DbSet<ProviderDepartment> ProviderDepartments { get; set; }
        //public DbSet<ProviderGroupBillingAddress> ProviderGroupBillingAddress { get; set; }
        //public DbSet<ProviderGroupLocation> ProviderGroupLocations { get; set; }
        //public DbSet<ProviderGroupLocationBillingAddress> ProviderGroupLocationBillingAddress { get; set; }
        //public DbSet<ProviderGroupLocationPhysicalAddress> ProviderGroupLocationPhysicalAddress { get; set; }
        //public DbSet<ProviderGroupOfficeHour> ProviderGroupOfficeHours { get; set; }
        //public DbSet<ProviderGroupPatient> ProviderGroupPatients { get; set; }
        //public DbSet<ProviderGroupPhysicalAddress> ProviderGroupPhysicalAddress { get; set; }
        //public DbSet<ProviderAcceptedInsurance> ProviderAcceptedInsurances { get; set; }
        //public DbSet<ProviderLicensedState> ProviderLicensedStates { get; set; }
        //public DbSet<ProviderSpokenLanguage> ProviderSpokenLanguages { get; set; }
        //public DbSet<ProviderType> ProviderTypes { get; set; }
        //public DbSet<ProviderWorkLocation> ProviderWorkLocations { get; set; }
        //public DbSet<Speciality> Speciality { get; set; }
    }
}
