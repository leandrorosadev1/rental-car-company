using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Api.Common;
using RentalCar.Api.Contracts;
using RentalCar.Application.Common.DTOs;
using RentalCar.Application.CustomerUsers.Login;
using RentalCar.Application.CustomerUsers.Register;

namespace RentalCar.Api.Controllers
{
    [ApiController]
    [Route("customers-auth")]
    [AllowAnonymous]
    public class CustomerUsersAuthenticationController : BaseController
    {
        private readonly IMediator _mediator;

        public CustomerUsersAuthenticationController(
            IMediator mediator,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = MapTo<CustomerUserRegisterCommand>(request);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(LoginRequest request)
        {
            var query = MapTo<CustomerUserLoginQuery>(request);
            AuthenticationResult result = await _mediator.Send(query);
            var response = MapTo<AuthenticationResponse>(result);
            return Ok(response);
        }
    }
}