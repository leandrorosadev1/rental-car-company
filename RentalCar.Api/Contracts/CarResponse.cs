namespace RentalCar.Api.Contracts
{
    public record CarResponse(
        int Id,
        string BrandName,
        string NumberPlate,
        bool IsActive,
        float DailyPrice,
        string PlacedInCountryName,
        List<DateTime> AvaiableDates);
}
