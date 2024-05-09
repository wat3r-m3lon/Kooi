using Kooi.Contracts.Tooltip;
using Kooi.Application.Tooltips.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using Kooi.Application.Tooltips.Queries;
using Kooi.Application.Responses;


namespace Kooi.WebAPI.Controllers
{
    public class TooltipController : ApiController
    {
        private readonly ILogger<TooltipController> _logger;
        private readonly IMediator _mediator;
        public TooltipController(IMediator mediator, ILogger<TooltipController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/tooltips")]
        public async Task<BaseResponse<List<GetTooltipResponse>>> GetAllTooltips()
        {
            var result = await _mediator.Send(new GetAllTooltipsQuery());
            return result;
        }

        [HttpGet]
        [Route("/tooltip/{tooltipId}")]
        public async Task<IActionResult> GetTooltipById([FromRoute] Guid tooltipId)
        {
            var result = await _mediator.Send(new GetTooltipByIdQuery(tooltipId));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
                );
        }

        [HttpPost]
        [Route("/tooltip")]
        public async Task<IActionResult> CreateTooltip([FromBody] CreateTooltipRequest request)
        {
            var result = await _mediator.Send(new CreateTooltipCommand(
                request.Title,
                request.ContentTypeId,
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
                request.RouteId));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }

        [HttpPut]
        [Route("/tooltip/{id}")]
        public async Task<IActionResult> UpdateToolTip([FromBody] CreateTooltipRequest request, [FromRoute] Guid id)
        {
            var result = await _mediator.Send(new UpdateTooltipCommand(
                id,
                request.Title,
                request.ContentTypeId,
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
                request.RouteId));
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }
    }
}
