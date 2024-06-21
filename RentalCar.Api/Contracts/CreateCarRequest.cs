using System.ComponentModel.DataAnnotations;

namespace RentalCar.Api.Contracts
{
    public record CreateCarRequest(
        int BrandId,
        [MaxLength(10)]
        string NumberPlate,
        float DailyPrice,
        int PlacedInCountryId,
        bool UseDefaultCalendar,
        DateTime? AvailableFromDate,
        DateTime? AvailableToDate);
}
