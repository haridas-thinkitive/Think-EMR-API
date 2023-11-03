using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;
using System.Data;
using System.Security;
using ThinkEMR_Care.DataAccess.Models.Roles_and_Responsibility;
using Role_And_Permission.Roles_and_Responsibility;

namespace ThinkEMR_Care.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ConfigureProviderGroupProfile(builder);
            SendRoles(builder);
            //SeedPermissionHelperData(builder);
            RolePermissionData(builder);
        }

        private void ConfigureProviderGroupProfile(ModelBuilder builder)
        {
            builder.Entity<ProviderGroupProfile>()
                .HasOne(p => p.PhysicalAddress)
                .WithMany()
                .HasForeignKey(p => p.PhysicalAddressId)
                .OnDelete(DeleteBehavior.NoAction);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProviderGroupProfile>()
                .HasOne(p => p.PhysicalAddress)
                .WithMany()
                .HasForeignKey(p => p.PhysicalAddressId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProviderGroupProfile> providerGroupProfiles { get; set; }
        public DbSet<Locations> locations { get; set; }
        public DbSet<Departments> departments { get; set; }
        public DbSet<PhysicalAddress> PhysicalAddress { get; set; }
        public DbSet<BillingAddress> BillingAddress { get; set; }
        public DbSet<PracticeOfficeHours> PracticeOfficeHours { get; set; }
        public DbSet<LocationsPhysicalAddress> LocationsPhysicalAddress { get; set; }
        public DbSet<LocationsBillingAddress> LocationsBillingAddress { get; set; }

       
        private void SendRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "SuperAdmin", NormalizedName = "SuperAdmin", ConcurrencyStamp = "1" },
                new IdentityRole() { Name = "Admin", NormalizedName = "Admin1", ConcurrencyStamp = "2" }
            );
        }

        //private void SeedPermissionHelperData(ModelBuilder builder)
        //{
        //    builder.Entity<RoleType>().HasData
        //    (
        //        new RoleType() { RoleTypeId = 1, RoleTypeName = "Appointment" },
        //        new RoleType() { RoleTypeId = 2, RoleTypeName = "Patient" },
        //        new RoleType() { RoleTypeId = 3, RoleTypeName = "Specialist" },
        //        new RoleType() { RoleTypeId = 4, RoleTypeName = "View To-Do List" },
        //        new RoleType() { RoleTypeId = 5, RoleTypeName = "Settings" }
        //    );
        //}

        private void RolePermissionData(ModelBuilder builder)
        {
            builder.Entity<RolePermission>()
            .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            builder.Entity<RolePermission>()
            .HasOne(rp => rp.Role)
            .WithMany()
            .HasForeignKey(rp => rp.RoleId); ;

            builder.Entity<RolePermission>()
            .HasOne(rp => rp.Permission)
            .WithMany()
            .HasForeignKey(rp => rp.PermissionId);
            //SeedPermissionHelperData(builder);
        }

        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<DashboardCount> DashboardCounts { get; set; }
        public DbSet<DashboardData> DashboardDatas { get; set; }
        public DbSet<ProviderGroupProfile> ProviderGroupProfiles { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Departments> Departments { get; set; }

        public DbSet<CPTCodeCatalog> CPTCodeCatalogs { get; set; }
        public DbSet<DataImport> DataImports { get; set; }
        public DbSet<HCPCSCodeCatalog> HCPCSCodeCatalogs { get; set; }
        public DbSet<ICD10CodeCatalog> ICD10CodeCatalogs { get; set; }
        public DbSet<LOINCCodeCatalog> LOINCCodeCatalogs { get; set; }
        public DbSet<DrugCatalog> DrugCatalogs { get; set; }

        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

    }
}
