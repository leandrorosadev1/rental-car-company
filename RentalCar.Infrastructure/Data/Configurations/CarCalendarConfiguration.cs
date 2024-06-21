using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalCar.Domain.Cars;

namespace RentalCar.Infrastructure.Data.Configurations
{
    public class CarCalendarConfiguration : IEntityTypeConfiguration<CarCalendar>
    {
        public void Configure(EntityTypeBuilder<CarCalendar> builder)
        {
            builder
                .Property(x => x.CalendarDate)
                .IsRequired();

            builder
                .HasIndex("CalendarDate", "CarId")
                .IsUnique();

            builder
                .Property(x => x.Version)
                .IsRequired()
                .HasDefaultValue(0);

            builder
                .Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(CarCalendarStatus.AVAILABLE);

            builder
                .HasOne(x => x.HoldByCustomerUser)
                .WithMany()
                .HasForeignKey("HoldByCustomerUserId")
                .IsRequired(false);

            builder
                .Property(x => x.HoldUpToDate);
        }
    }
}
