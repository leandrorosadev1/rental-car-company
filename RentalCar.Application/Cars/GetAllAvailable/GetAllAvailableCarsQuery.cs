using MediatR;
using RentalCar.Domain.Cars;

namespace RentalCar.Application.Cars.GetAllAvailable
{
    public record GetAllAvailableCarsQuery(
        DateTime FromDate,
        DateTime ToDate,
        int CountryId,
        int PageNumber,
        int RowsPerPage) : IRequest<List<AvailableCar>>;


}
