
using ErrorOr;
using Kooi.Application.Responses;
using Kooi.Contracts.Tooltip;
using Kooi.Domain.Repositories;
using MediatR;

namespace Kooi.Application.Tooltips.Queries
{
    internal class GetTooltipByIdQueryHandler : IRequestHandler<GetTooltipByIdQuery, ErrorOr<BaseResponse<GetTooltipResponse>>>
    {
        private readonly ITooltipInstructionsRepository _tooltipInstructionsRepository;
        private readonly ITooltipsRepository _tooltipsRepository;

        public GetTooltipByIdQueryHandler(ITooltipInstructionsRepository tooltipInstructionsRepository, ITooltipsRepository tooltipsRepository)
        {
            _tooltipInstructionsRepository = tooltipInstructionsRepository;
            _tooltipsRepository = tooltipsRepository;
        }

        public async Task<ErrorOr<BaseResponse<GetTooltipResponse>>> Handle(GetTooltipByIdQuery request, CancellationToken cancellationToken)
        {
            var tooltipResult = await _tooltipsRepository.GetTooltipByIdAsync(request.Id);
            var instructionResult = await _tooltipInstructionsRepository.GetInstructionByTooltipIdAsync(request.Id);
            if (!tooltipResult.IsError && !instructionResult.IsError)
            {
                var tooltip = tooltipResult.Value;
                var instruction = instructionResult.Value;
                var getTooltipResponse = new GetTooltipResponse(
                    tooltip.Id,
                    tooltip.Title,
                    tooltip.ContentTypeId,
                    tooltip.Description,
                    tooltip.ShowProgress,
                    tooltip.ProgressText,
                    tooltip.NextBtnText,
                    tooltip.PrevBtnText,
                    tooltip.DoneBtnText,
                    instruction.ElementIdentifier,
                    instruction.IconId,
                    instruction.IconSideId,
                    instruction.IconAlignId,
                    instruction.RouteId
                    );
                return new BaseResponse<GetTooltipResponse>(getTooltipResponse);   
            }
            return tooltipResult.Errors;
        }
    }
}
