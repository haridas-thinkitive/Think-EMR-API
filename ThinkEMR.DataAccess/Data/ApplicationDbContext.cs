using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ThinkEMR_Care.DataAccess.Models;
using ThinkEMR_Care.DataAccess.Models.MasterPageModels;

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
        }

        private void ConfigureProviderGroupProfile(ModelBuilder builder)
        {
            builder.Entity<ProviderGroupProfile>()
                .HasOne(p => p.PhysicalAddress)
                .WithMany()
                .HasForeignKey(p => p.PhysicalAddressId)
                .OnDelete(DeleteBehavior.NoAction); // Specify NO ACTION here
        }

        private void SendRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin1", NormalizedName = "Admin1", ConcurrencyStamp = "1" },
                new IdentityRole() { Name = "Admin2", NormalizedName = "Admin2", ConcurrencyStamp = "2" }
            );
        }

        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<DashboardCount> DashboardCounts { get; set; }
        public DbSet<DashboardData> DashboardDatas { get; set; }
        public DbSet<ProviderGroupProfile> providerGroupProfiles { get; set; }
        public DbSet<Locations> locations { get; set; }
        public DbSet<Departments> departments { get; set; }

        //Sagar Model Classes
        public DbSet<CPTCodeCatalog> cPTCodeCatalogs { get; set; }
        public DbSet<DataImport> dataImports { get; set; }
        public DbSet<HCPCSCodeCatalog> hPCSCodeCatalogs { get; set; }
        public DbSet<ICD10CodeCatalog> icD10CodeCatalogs { get; set; }
        public DbSet<LOINCCodeCatalog> loINCCodeCatalogs { get; set; }
        public DbSet<DrugCatalog> drugCatalogs { get; set; }
    }
}
