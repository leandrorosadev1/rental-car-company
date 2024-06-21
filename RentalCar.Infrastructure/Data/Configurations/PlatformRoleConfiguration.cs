using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCar.Domain.Permissions;

namespace RentalCar.Infrastructure.Data.Configurations
{
    public class PlatformRoleConfiguration : IEntityTypeConfiguration<PlatformRole>
    {
        public void Configure(EntityTypeBuilder<PlatformRole> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .HasMany(e => e.Permissions)
                .WithMany();
        }
    }
}
