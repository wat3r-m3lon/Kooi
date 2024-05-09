using MediatR;
using Microsoft.AspNetCore.Mvc;
using Kooi.Application.Roles.Queries;

namespace Kooi.WebAPI.Controllers
{
    public class RoleController : ApiController
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IMediator _mediator;
        public RoleController(IMediator mediator, ILogger<RoleController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _mediator.Send(new GetAllRolesQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("/role/{name}")]
        public async Task<IActionResult> GetTRoleByName([FromRoute] string name)
        {
            var result = await _mediator.Send(new GetRoleByNameQuery(name));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
                );
        }

        [HttpGet]
        [Route("/role")]
        public async Task<IActionResult> GetTRoleById([FromHeader] Guid id)
        {
            var result = await _mediator.Send(new GetRoleByIdQuery(id));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
                );
        }
    }
}
