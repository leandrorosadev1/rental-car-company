using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCar.Domain.Permissions;

namespace RentalCar.Infrastructure.Data.Configurations
{
    public class PlatformPermissionConfiguration : IEntityTypeConfiguration<PlatformPermission>
    {
        public void Configure(EntityTypeBuilder<PlatformPermission> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
