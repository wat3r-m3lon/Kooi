using ErrorOr;
using Kooi.Application.Data;
using Kooi.Domain.Repositories;
using MediatR;
using Kooi.Domain.Common.Errors;
using Kooi.Domain.Models.Tooltips;

namespace Kooi.Application.Tooltips.Commands
{
    internal sealed class UpdateTooltipCommandHandler : IRequestHandler<UpdateTooltipCommand, ErrorOr<bool>>
    {

        private readonly ITooltipsRepository _tooltipsRepository;
        private readonly ITooltipInstructionsRepository _tooltipInstructionsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTooltipCommandHandler(
            ITooltipsRepository tooltipsRepository, 
            ITooltipInstructionsRepository tooltipInstructionsRepository, 
            IUnitOfWork unitOfWork)
        {

            _tooltipsRepository = tooltipsRepository;
            _tooltipInstructionsRepository = tooltipInstructionsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<bool>> Handle(UpdateTooltipCommand command, CancellationToken cancellationToken)
        {

            try
            {
                _unitOfWork.BeginTransaction();
                var tooltipResult = await _tooltipsRepository.UpdateTooltipAsync(Tooltip.Create(
                    command.Id,
                    command.Title,
                    command.ContenTtypeId,
                    command.Description,
                    command.ShowProgress,
                    command.ProgressText,
                    command.NextBtnText,
                    command.PrevBtnText,
                    command.DoneBtnText
                    ));
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                var instruction = await _tooltipInstructionsRepository.GetInstructionByTooltipIdAsync(command.Id);
                if (instruction.IsError)
                {
                    return instruction.Errors;
                }
                var result = await _tooltipInstructionsRepository.UpdateTooltipInstructionAsync(TooltipInstruction.Create(
                    instruction.Value.Id,
                    command.ElementIdentifier,
                    command.Id,
                    command.IconId,
                    command.IconSideId,
                    command.IconAlignId,
                    command.RouteId
                    ));
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                _unitOfWork.CommitTransaction();
                return tooltipResult;
            }
            catch (Exception)
            {
                return Errors.Tooltip.UpdateFail;
            }
        }
    }
}
