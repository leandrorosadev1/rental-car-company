using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Api.Common;
using RentalCar.Api.Contracts;
using RentalCar.Application.Rentals.Cancel;
using RentalCar.Application.Rentals.Confirm;
using RentalCar.Application.Rentals.GetById;
using RentalCar.Application.Rentals.Return;
using RentalCar.Application.Rentals.Start;

namespace RentalCar.Api.Controllers
{
    [ApiController]
    [Route("rentals")]
    public class RentalsController : BaseController
    {
        private readonly IMediator _mediator;

        public RentalsController(
            IMediator mediator,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpPost("reservation")]
        [Authorize(Policy = "RENTAL_ADD")]
        public async Task<IActionResult> StartRental(CreateRentalRequest request)
        {
            var command = MapTo<StartRentalCommand>(request);
            command.CustomerUserId = GetCurrentUserId().Value;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("confirmation")]
        [Authorize(Policy = "RENTAL_ADD")]
        public async Task<ActionResult<RentalResponse>> ConfirmRental(CreateRentalRequest request)
        {
            var command = MapTo<ConfirmRentalCommand>(request);
            command.CustomerUserId = GetCurrentUserId().Value;
            var rentalId = await _mediator.Send(command);

            var query = new GetRentalByIdQuery(rentalId);
            var rental = await _mediator.Send(query);

            var response = MapTo<RentalResponse>(rental);
            return Ok(response);
        }

        [HttpPut("{id}/cancellation")]
        [Authorize(Policy = "RENTAL_CANCEL")]
        public async Task<ActionResult> CancelRental(int id)
        {
            var command = new CancelRentalCommand(
                id,
                CurrentUserIsAdmin ? null : GetCurrentUserId().Value);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}/return")]
        [Authorize(Policy = "RENTAL_RETURN")]
        public async Task<ActionResult> ReturnCarOfRental(int id)
        {
            var command = new ReturnRentalCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
