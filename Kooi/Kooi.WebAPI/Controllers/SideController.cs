using MediatR;
using Microsoft.AspNetCore.Mvc;
using Kooi.Application.Sides.Queries;

namespace Kooi.WebAPI.Controllers
{
    public class SideController : ApiController
    {
        private readonly ILogger<SideController> _logger;
        private readonly IMediator _mediator;
        public SideController(IMediator mediator, ILogger<SideController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/sides")]
        public async Task<IActionResult> GetAllSides()
        {
            var result = await _mediator.Send(new GetAllSidesQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("/side/{name}")]
        public async Task<IActionResult> GetTSideByName([FromRoute] string name)
        {
            var result = await _mediator.Send(new GetSideByNameQuery(name));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
                );
        }

        [HttpGet]
        [Route("/side")]
        public async Task<IActionResult> GetTSideById([FromHeader] Guid id)
        {
            var result = await _mediator.Send(new GetSideByIdQuery(id));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
                );
        }
    }
}
