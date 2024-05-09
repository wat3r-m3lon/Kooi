using Kooi.Application.Responses;
using Kooi.Contracts.Tooltip;
using Kooi.Domain.Models.Tooltips;
using Kooi.Domain.Repositories;
using MediatR;

namespace Kooi.Application.Tooltips.Queries
{
    internal class GetAllTooltipsQueryHandler : IRequestHandler<GetAllTooltipsQuery, BaseResponse<List<GetTooltipResponse>>>
    {
        private readonly ITooltipInstructionsRepository _tooltipInstructionsRepository;
        private readonly ITooltipsRepository _tooltipsRepository;

        public GetAllTooltipsQueryHandler(ITooltipInstructionsRepository tooltipInstructionsRepository, ITooltipsRepository tooltipsRepository)
        {
            _tooltipInstructionsRepository = tooltipInstructionsRepository;
            _tooltipsRepository = tooltipsRepository;
        }

        public async Task<BaseResponse<List<GetTooltipResponse>>> Handle(GetAllTooltipsQuery request, CancellationToken cancellationToken)
        {
            //hard code id for tooltips for now
            List<Tooltip> basicTooltips = await _tooltipsRepository.GetTooltipsByContentIdAsync("7E7757FC-745C-41C7-A7FE-1C8E265DDD1D");
            List<GetTooltipResponse> responses = new List<GetTooltipResponse>();

            foreach (Tooltip tooltip in basicTooltips)
            {
                var instructionResult = await _tooltipInstructionsRepository.GetInstructionByTooltipIdAsync(tooltip.Id);
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
                responses.Add(getTooltipResponse);

            }
            return new BaseResponse<List<GetTooltipResponse>>(responses);
        }
    }
}
