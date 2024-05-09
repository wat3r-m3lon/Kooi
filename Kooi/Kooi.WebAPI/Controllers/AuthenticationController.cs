using ErrorOr;
using Kooi.Application.Users.Authentication.Commands;
using Kooi.Contracts.Authentication;
using Kooi.WebAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kooi.WebApi.Controllers
{

    [ApiController]
    public class AuthenticationController : ApiController
    {

        private readonly ILogger<AuthenticationController> _logger;
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator, ILogger<AuthenticationController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            ErrorOr<AuthenticationResult> result = await _mediator.Send(
            new RegisterAdminUserCommand(request.Fullname, request.Email, request.Password, request.RoleId, request.NetworkId));
            return result.Match(
            result => Ok(result.Token),
            errors => Problem(errors)
            );
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest request)
        {
            var response = await _mediator.Send(new LoginCommand(request.Email, request.Password));
            ErrorOr<AuthenticationResult> result = await _mediator.Send(new LoginCommand(request.Email, request.Password));
            return result.Match(
                result => Ok(result.Token),
                errors => Problem(errors)
            );
        }

        //API for auth testing
        [Route("AuthorizationTest")]
        [HttpGet]
        [Authorize]
        public Object Data()
        {
            return "OK";
        }

    }
}
