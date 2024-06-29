using CarManagementApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarManagementApp.Infrastructure.Data.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.HasIndex(e => e.Id).IsUnique();
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Model).IsRequired();
            builder.Property(e => e.Make).IsRequired();
            builder.Property(e => e.Year).IsRequired();
            builder.Property(e => e.CreatedAtAS).IsRequired();
        }
    }
}
