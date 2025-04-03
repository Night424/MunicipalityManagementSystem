using Microsoft.EntityFrameworkCore;

namespace MunicipalityManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MunicipalityManagementSystem.Models.Citizen> Citizens { get; set; }
        public DbSet<MunicipalityManagementSystem.Models.ServiceRequest> ServiceRequests { get; set; }
        public DbSet<MunicipalityManagementSystem.Models.Staff> Staff { get; set; }
        public DbSet<MunicipalityManagementSystem.Models.Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints
            modelBuilder.Entity<MunicipalityManagementSystem.Models.ServiceRequest>()
                .HasOne(sr => sr.Citizen)
                .WithMany(c => c.ServiceRequests)
                .HasForeignKey(sr => sr.CitizenID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MunicipalityManagementSystem.Models.Report>()
                .HasOne(r => r.Citizen)
                .WithMany(c => c.Reports)
                .HasForeignKey(r => r.CitizenID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
