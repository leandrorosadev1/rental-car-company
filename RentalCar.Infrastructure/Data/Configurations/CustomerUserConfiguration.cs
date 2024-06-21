using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCar.Domain.Users;

namespace RentalCar.Infrastructure.Data.Configurations
{
    public class CustomerUserConfiguration : IEntityTypeConfiguration<CustomerUser>
    {
        public void Configure(EntityTypeBuilder<CustomerUser> builder)
        {
            builder
                .Property(x => x.Firstname)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(x => x.Lastname)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(x => x.IdCardNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder
               .Property(x => x.DriverLicenseNumber)
               .IsRequired()
               .HasMaxLength(128);

            builder
                .HasIndex(x => new { x.Email, x.Password });

            builder.Ignore(x => x.CurrentAge);
        }
    }
}
