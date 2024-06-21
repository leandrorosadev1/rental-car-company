using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCar.Domain.Cars;

namespace RentalCar.Infrastructure.Data.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasOne(x => x.Brand)
                .WithMany()
                .HasForeignKey("CarBrandId");

            builder
                .Property(x => x.NumberPlate)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .HasOne(x => x.PlacedInCountry)
                .WithMany()
                .HasForeignKey("PlacedInCountryId");

            builder
               .HasMany(x => x.Calendar)
               .WithOne(cc => cc.Car)
               .HasForeignKey("CarId");

            builder
               .HasIndex(x => x.NumberPlate)
               .IsUnique();
        }
    }
}
