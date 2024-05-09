using ErrorOr;
using Kooi.Application.Routes.Commands;
using Kooi.Contracts.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Kooi.WebAPI.Controllers
{
    
    [ApiController]
    public class RouteController : ApiController
    {
        private readonly ILogger<RouteController> _logger;
        private readonly IMediator _mediator;
        public RouteController(IMediator mediator, ILogger<RouteController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/route")]
        public async Task<ErrorOr<Guid>> CreateRoute(CreateRouteRequest createrouteRequest)
        {
            return await _mediator.Send(new CreateRouteCommand(createrouteRequest.Uri));
        }
    }
}
