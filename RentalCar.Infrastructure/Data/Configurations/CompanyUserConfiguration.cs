using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCar.Domain.Users;

namespace RentalCar.Infrastructure.Data.Configurations
{
    public class CompanyUserConfiguration : IEntityTypeConfiguration<CompanyUser>
    {
        public void Configure(EntityTypeBuilder<CompanyUser> builder)
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
                .HasOne(x => x.PlatformRole)
                .WithMany()
                .HasForeignKey("PlatformRoleId");

            builder
                .HasIndex(x => new { x.Email, x.Password });
        }
    }
}
