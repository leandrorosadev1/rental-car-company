using MediatR;

namespace RentalCar.Application.Cars.Create
{
    public record CreateCarCommand(
        int BrandId,
        string NumberPlate,
        float DailyPrice,
        int PlacedInCountryId,
        bool UseDefaultCalendar,
        DateTime? AvailableFromDate,
        DateTime? AvailableToDate) : IRequest<int>;

}
