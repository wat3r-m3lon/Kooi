using MediatR;
using Microsoft.AspNetCore.Mvc;
using Kooi.Application.ContentTypes.Queries;

namespace Kooi.WebAPI.Controllers
{
    public class ContentTypeController : ApiController
    {
        private readonly ILogger<ContentTypeController> _logger;
        private readonly IMediator _mediator;
        public ContentTypeController(IMediator mediator, ILogger<ContentTypeController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/contentTypes")]
        public async Task<IActionResult> GetAllContentTypes()
        {
            var result = await _mediator.Send(new GetAllContentTypesQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("/contentType/{type}")]
        public async Task<IActionResult> GetTContentTypeByType([FromRoute] string type)
        {
            var result = await _mediator.Send(new GetContentTypeByTypeQuery(type));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
                );
        }

        [HttpGet]
        [Route("/contentType")]
        public async Task<IActionResult> GetTContentTypeById([FromHeader] Guid id)
        {
            var result = await _mediator.Send(new GetContentTypeByIdQuery(id));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
                );
        }
    }
}
