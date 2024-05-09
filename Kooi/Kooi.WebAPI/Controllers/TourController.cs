using ErrorOr;
using Kooi.Application.Tours.Commands;
using Kooi.Contracts.Tours;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Kooi.WebAPI.Controllers
{
    
    public class TourController : ApiController
    {
        private readonly ILogger<TourController> _logger;
        private readonly IMediator _mediator;
        public TourController(IMediator mediator, ILogger<TourController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/tour")]
        public async Task<IActionResult> CreateTour([FromBody] CreateTourRequest request)
        {
            var result = await _mediator.Send(
                new CreateTourCommand(
                    request.Name,
                    request.RouteId,
                    request.Required,
                    request.UserId
                    ));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }
    }
}
