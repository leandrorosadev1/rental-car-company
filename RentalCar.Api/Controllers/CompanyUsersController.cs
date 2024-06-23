using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalCar.Api.Common;
using RentalCar.Api.Contracts;
using RentalCar.Application.Common.DTOs;
using RentalCar.Application.CompanyUsers.Login;

namespace RentalCar.Api.Controllers
{
    [ApiController]
    [Route("company-users")]
    [AllowAnonymous]
    public class CompanyUsersController : BaseController
    {
        private readonly IMediator _mediator;

        public CompanyUsersController(
            IMediator mediator,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(LoginRequest request)
        {
            var query = MapTo<CompanyUserLoginQuery>(request);
            AuthenticationResult result = await _mediator.Send(query);
            var response = MapTo<AuthenticationResponse>(result);
            return Ok(response);
        }
    }
}
