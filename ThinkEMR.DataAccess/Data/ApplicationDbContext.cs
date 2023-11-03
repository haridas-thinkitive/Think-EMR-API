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

        
    }
}
