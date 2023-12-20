using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;
using ThinkEMR_Care.DataAccess.Models.Roles_and_Responsibility;
using ThinkEMR_Care.DataAccess.Models.Authentication.CustomData;
using ThinkEMR_Care.DataAccess.Models.RolesAndResponsibility;

namespace ThinkEMR_Care.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ConfigureProviderGroupProfile(builder);
            SendRoles(builder);
        }

        private void ConfigureProviderGroupProfile(ModelBuilder builder)
        {
            builder.Entity<ProviderGroupProfile>()
                .HasOne(p => p.PhysicalAddress)
                .WithMany()
                .HasForeignKey(p => p.PhysicalAddressId)
                .OnDelete(DeleteBehavior.NoAction);

           
        }

        private void SendRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "SuperAdmin", NormalizedName = "SuperAdmin", ConcurrencyStamp = "1" },
                new IdentityRole() { Name = "Admin", NormalizedName = "Admin1", ConcurrencyStamp = "2" }
            );
        }

        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<DashboardCount> DashboardCounts { get; set; }
        public DbSet<DashboardData> DashboardDatas { get; set; }

        //Provider Groups
        public DbSet<ProviderGroupProfile> ProviderGroupProfiles { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<ProviderGroupProfile> providerGroupProfiles { get; set; }
        public DbSet<PhysicalAddress> PhysicalAddress { get; set; }
        public DbSet<BillingAddress> BillingAddress { get; set; }
        public DbSet<PracticeOfficeHours> PracticeOfficeHours { get; set; }
        public DbSet<LocationsPhysicalAddress> LocationsPhysicalAddress { get; set; }
        public DbSet<LocationsBillingAddress> LocationsBillingAddress { get; set; }
        public DbSet<StaffUser> StaffUsers { get; set; }
        public DbSet<ProviderUser> ProviderUsers { get; set; }
        public DbSet<BasicAccountProfileData> BasicAccountProfileData { get; set; }


        //Master
        public DbSet<CPTCodeCatalog> CPTCodeCatalogs { get; set; }
        public DbSet<DataImport> DataImports { get; set; }
        public DbSet<HCPCSCodeCatalog> HCPCSCodeCatalogs { get; set; }
        public DbSet<ICD10CodeCatalog> ICD10CodeCatalogs { get; set; }
        public DbSet<LOINCCodeCatalog> LOINCCodeCatalogs { get; set; }
        public DbSet<DrugCatalog> DrugCatalogs { get; set; }

        //Roles and Resposibility
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        public DbSet<Notification> notifications { get; set; }

    }
}
