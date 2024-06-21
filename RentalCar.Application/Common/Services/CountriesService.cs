using Microsoft.EntityFrameworkCore;
using RentalCar.Application.Common.Exceptions;
using RentalCar.Domain.Common;
using RentalCar.Infrastructure.Data;

namespace RentalCar.Application.Common.Services
{
    public class CountriesService
    {
        private RentalCarDbContext _context;

        public CountriesService(RentalCarDbContext context)
        {
            _context = context;
        }

        public virtual async Task<Country> GetCountryById(int countryId)
        {
            Country country = await _context.Countries.Where(c => c.Id == countryId).SingleOrDefaultAsync();
            if (country == null)
            {
                throw new ApplicationLayerException(
                    ApplicationLayerExceptionType.NOT_FOUND,
                    "COUNTRY_NOT_FOUND",
                    $"Country with id {countryId} was not found");
            }
            return country;
        }
    }
}
