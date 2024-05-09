using Kooi.Application.TourSteps.Commands;
using Kooi.Contracts.Tours;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kooi.WebAPI.Controllers
{
    
    public class TourStepController : ApiController
    {
        private readonly ILogger<TourController> _logger;
        private readonly IMediator _mediator;
        public TourStepController(IMediator mediator, ILogger<TourController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/tourStep")]
        public async Task<IActionResult> CreateTourStep([FromBody] CreateTourStepRequest request)
        {
            var result = await _mediator.Send(
                new CreateTourStepCommand(
                    request.TourId,
                    request.Sequence,
                    request.AlignId,
                    request.SideId,
                    request.Title,
                    request.ContenTtypeId,
                    request.Description,
                    request.ShowProgress,
                    request.ProgressText,
                    request.NextBtnText,
                    request.PrevBtnText,
                    request.DoneBtnText,
                    request.ElementIdentifier,
                    request.IconId,
                    request.IconSideId,
                    request.IconAlignId,
                    request.RouteId
                    ));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }

        [HttpPut]
        [Route("/tourStep/{id}")]
        public async Task<IActionResult> UpdateTourStep([FromBody] UpdateTourStepRequest request, [FromRoute] Guid id)
        {
            var result = await _mediator.Send(
                new UpdateTourStepCommand(
                    id,
                    request.TourId,
                    request.Sequence,
                    request.TooltipId,
                    request.AlignId,
                    request.SideId,
                    request.Title,
                    request.ContenTtypeId,
                    request.Description,
                    request.ShowProgress,
                    request.ProgressText,
                    request.NextBtnText,
                    request.PrevBtnText,
                    request.DoneBtnText,
                    request.ElementIdentifier,
                    request.IconId,
                    request.IconSideId,
                    request.IconAlignId,
                    request.RouteId
                    ));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }
    }
}
