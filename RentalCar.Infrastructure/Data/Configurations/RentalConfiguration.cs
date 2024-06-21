using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCar.Domain.Rentals;

namespace RentalCar.Infrastructure.Data.Configurations
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder
                .HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey("CustomerUserId")
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Car)
                .WithMany()
                .HasForeignKey("CarId");

            builder
                .Property(x => x.FromDate);

            builder
                .Property(x => x.ToDate);

            builder
                .Property(x => x.DailyPrice);

            builder
                .Property(x => x.TotalPrice);
        }
    }
}
