using CarManagementApp.Domain.Entities;
using CarManagementApp.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CarManagementApp.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<CarEntity> Cars { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CarConfiguration());

            modelBuilder.Entity<CarEntity>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
