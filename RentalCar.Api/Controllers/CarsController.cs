using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Api.Common;
using RentalCar.Api.Contracts;
using RentalCar.Application.Cars.Create;
using RentalCar.Application.Cars.Delete;
using RentalCar.Application.Cars.GetAllAvailable;
using RentalCar.Application.Cars.GetById;

namespace RentalCar.Api.Controllers
{
    [ApiController]
    [Route("cars")]
    public class CarsController : BaseController
    {
        private readonly IMediator _mediator;

        public CarsController(
            IMediator mediator,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Policy = "VEHICLE_ADD")]
        public async Task<ActionResult<CarResponse>> CreateCar(CreateCarRequest request)
        {
            var command = MapTo<CreateCarCommand>(request);
            int id = await _mediator.Send(command);

            var query = new GetCarByIdQuery(id);
            var car = await _mediator.Send(query);

            var response = MapTo<CarResponse>(car);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CarResponse>> GetCarById(int id)
        {
            var query = new GetCarByIdQuery(id);
            var car = await _mediator.Send(query);

            var response = MapTo<CarResponse>(car);
            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<AvailableCarsListResponse>> GetAllCars(
            DateTime fromDate,
            DateTime toDate,
            int countryId,
            int pageNumber = 0,
            int rowsPerPage = 20)
        {
            var query = new GetAllAvailableCarsQuery(fromDate, toDate, countryId, pageNumber, rowsPerPage);
            var cars = await _mediator.Send(query);

            var response = new AvailableCarsListResponse();
            foreach (var car in cars)
            {
                response.Data.Add(new AvailableCarsListResponse.AvailableCarResponse(
                    car.Id,
                    car.BrandName,
                    car.NumberPlate,
                    car.DailyPrice));
                response.TotalResults = car.TotalCount;
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "VEHICLE_REMOVE")]
        public async Task<ActionResult> DeleteCar(int id)
        {
            var command = new DeleteCarCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
