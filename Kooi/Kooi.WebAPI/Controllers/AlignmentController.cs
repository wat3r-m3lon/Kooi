using MediatR;
using Microsoft.AspNetCore.Mvc;
using Kooi.Application.ContentTypes.Queries;
using Kooi.Application.Alignments.Queries;

namespace Kooi.WebAPI.Controllers
{
    public class AlignmentController : ApiController
    {
        private readonly ILogger<AlignmentController> _logger;
        private readonly IMediator _mediator;
        public AlignmentController(IMediator mediator, ILogger<AlignmentController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/alignments")]
        public async Task<IActionResult> GetAllAlignments()
        {
            var result = await _mediator.Send(new GetAllAlignmentsQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("/alignment")]
        public async Task<IActionResult> GetTAlignmentById([FromHeader] Guid id)
        {
            var result = await _mediator.Send(new GetAlignmentByIdQuery(id));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
                );
        }

        [HttpGet]
        [Route("/alignment/{name}")]
        public async Task<IActionResult> GetTAlignmentByName([FromRoute] string name)
        {
            var result = await _mediator.Send(new GetAlignmentByNameQuery(name));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
                );
        }
    }
}
