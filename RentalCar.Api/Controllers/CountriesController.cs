using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Api.Common;
using RentalCar.Api.Contracts;
using RentalCar.Application.Countries.GetAll;

namespace RentalCar.Api.Controllers
{
    [ApiController]
    [Route("countries")]
    public class CountriesController : BaseController
    {
        private readonly IMediator _mediator;

        public CountriesController(
            IMediator mediator,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<CountryResponse>>> GetCountries()
        {
            var query = new GetAllCountriesQuery();
            var countries = await _mediator.Send(query);
            var response = MapTo<List<CountryResponse>>(countries);
            return Ok(response);
        }
    }
}
