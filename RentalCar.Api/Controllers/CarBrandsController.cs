using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Api.Common;
using RentalCar.Api.Contracts;
using RentalCar.Application.CarBrands.GetAll;

namespace RentalCar.Api.Controllers
{
    [ApiController]
    [Route("car-brands")]
    public class CarBrandsController : BaseController
    {
        private readonly IMediator _mediator;

        public CarBrandsController(
            IMediator mediator,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<CarBrandResponse>>> GetBrands()
        {
            var query = new GetAllCarBrandsQuery();
            var carBrands = await _mediator.Send(query);
            var response = MapTo<List<CarBrandResponse>>(carBrands);
            return Ok(response);
        }
    }
}
