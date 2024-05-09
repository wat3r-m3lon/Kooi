
using Kooi.Application.Responses;
using Kooi.Application.Users.Authentication.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Kooi.Contracts.Users;
using Kooi.Application.Users.Authentication.Commands;
using Kooi.WebAPI.Controllers;
using ErrorOr;

namespace WebApi.Controllers
{
   
    public class UserController : ApiController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/adminUsers")]
        public async Task<BaseResponse<List<GetAdminUserResponse>>> GetAllAdminUsers()
        {
            var result = await _mediator.Send(new GetAllAdminUsersQuery());
            return result;
        }

        [HttpGet]
        [Route("/adminUser/{firebaseId}")]
        public async Task<IActionResult> GetAdminUserById([FromRoute] string firebaseId)
        {
            var result = await _mediator.Send(new GetAdminUserByFirebaseIdQuery(firebaseId));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }

        // This controller is just for testing
        [HttpPost]
        [Route("/User")]
        public async Task<ErrorOr<Guid>> CreateUser(CreateUserRequest createUserRequest)
        {
            return await _mediator.Send(new CreateUserCommand(createUserRequest.NetwrokId));
     
        }
    }
}
