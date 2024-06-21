using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Api.Common;
using RentalCar.Application.CustomerUsers.Delete;

namespace RentalCar.Api.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerUsersController : BaseController
    {
        private readonly IMediator _mediator;

        public CustomerUsersController(
            IMediator mediator,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CUSTOMER_REMOVE")]
        public async Task<ActionResult> CreateCar(int id)
        {
            if (!CurrentUserIsAdmin && id != GetCurrentUserId().Value)
            {
                return BadRequest();
            }
            var command = new DeleteCustomerUserCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
