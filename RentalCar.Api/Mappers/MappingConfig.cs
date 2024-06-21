using Mapster;
using RentalCar.Api.Contracts;
using RentalCar.Application.Cars.Create;
using RentalCar.Application.Common.DTOs;
using RentalCar.Application.CompanyUsers.Login;
using RentalCar.Application.CustomerUsers.Login;
using RentalCar.Application.CustomerUsers.Register;
using RentalCar.Application.Rentals.Confirm;
using RentalCar.Application.Rentals.Start;
using RentalCar.Domain.Cars;
using RentalCar.Domain.Common;
using RentalCar.Domain.Rentals;

namespace RentalCar.Api.Mappers
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, CustomerUserRegisterCommand>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);

            config.NewConfig<LoginRequest, CustomerUserLoginQuery>();

            config.NewConfig<LoginRequest, CompanyUserLoginQuery>();

            config.NewConfig<CreateCarRequest, CreateCarCommand>();

            config.NewConfig<Car, CarResponse>()
                .Map(dest => dest.BrandName, src => src.Brand.Name)
                .Map(dest => dest.PlacedInCountryName, src => src.PlacedInCountry.Name)
                .Map(dest => dest.AvaiableDates, src => src.Calendar.Select(c => c.CalendarDate).ToList());

            config.NewConfig<CreateRentalRequest, StartRentalCommand>()
                .Ignore(dest => dest.CustomerUserId);

            config.NewConfig<CreateRentalRequest, ConfirmRentalCommand>()
                .Ignore(dest => dest.CustomerUserId);

            config.NewConfig<Rental, RentalResponse>()
                .Map(dest => dest.CarId, src => src.Car.Id)
                .Map(dest => dest.CarNumberPlate, src => src.Car.NumberPlate)
                .Map(dest => dest.CustomerUserId, src => src.Customer.Id)
                .Map(dest => dest.Status, src => src.Status.ToString());

            config.NewConfig<Country, CountryResponse>();

            config.NewConfig<CarBrand, CarBrandResponse>();
        }
    }
}
