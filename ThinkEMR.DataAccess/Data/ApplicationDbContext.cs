using Microsoft.EntityFrameworkCore;
using ThinkEMR_Care.DataAccess.Models;

namespace ThinkEMR_Care.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        /*protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProviderGroupProfile>()
                .HasOne(p => p.PhysicalAddress)
                .WithMany()
                .HasForeignKey(p => p.PhysicalAddressId)
                .OnDelete(DeleteBehavior.NoAction); // Specify NO ACTION here

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProviderGroupProfile> providerGroupProfiles { get; set; }
        public DbSet<Locations> locations { get; set; }
        public DbSet<Departments> departments { get; set; }
       
    }
}
