using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Api.Common;
using RentalCar.Api.Contracts;
using RentalCar.Application.Common.DTOs;
using RentalCar.Application.CustomerUsers.Delete;
using RentalCar.Application.CustomerUsers.Login;
using RentalCar.Application.CustomerUsers.Register;

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

        [HttpPost("registration")]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            var command = MapTo<CustomerUserRegisterCommand>(request);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthenticationResponse>> Login(LoginRequest request)
        {
            var query = MapTo<CustomerUserLoginQuery>(request);
            AuthenticationResult result = await _mediator.Send(query);
            var response = MapTo<AuthenticationResponse>(result);
            return Ok(response);
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
            return NoContent();
        }
    }
}
