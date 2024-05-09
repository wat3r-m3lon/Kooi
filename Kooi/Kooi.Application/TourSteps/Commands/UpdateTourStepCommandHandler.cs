using ErrorOr;
using Kooi.Application.Data;
using Kooi.Domain.Models.Tooltips;
using Kooi.Domain.Repositories;
using MediatR;
using Kooi.Domain.Common.Errors;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Kooi.Domain.Models.Tours;

namespace Kooi.Application.TourSteps.Commands
{
    internal sealed class UpdateTourStepCommandHandler : IRequestHandler<UpdateTourStepCommand, ErrorOr<bool>>
    {
        private readonly ITourStepsRepository _tourStepsRepository;
        private readonly ITooltipsRepository _tooltipsRepository;
        private readonly ITooltipInstructionsRepository _tooltipInstructionsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTourStepCommandHandler(
            ITourStepsRepository tourStepsRepository,
            ITooltipsRepository tooltipsRepository,
            ITooltipInstructionsRepository tooltipInstructionsRepository,
            IUnitOfWork unitOfWork)
        {
            _tourStepsRepository = tourStepsRepository;
            _tooltipsRepository = tooltipsRepository;
            _tooltipInstructionsRepository = tooltipInstructionsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<bool>> Handle(UpdateTourStepCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var tooltipResult = await _tooltipsRepository.UpdateTooltipAsync(Tooltip.Create(
                    command.TooltipId,
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
                var instruction = await _tooltipInstructionsRepository.GetInstructionByTooltipIdAsync(command.TooltipId);
                if (instruction.IsError)
                {
                    return instruction.Errors;
                }
                var instructionResult = await _tooltipInstructionsRepository.UpdateTooltipInstructionAsync(TooltipInstruction.Create(
                    instruction.Value.Id,
                    command.ElementIdentifier,
                    command.TooltipId,
                    command.IconId,
                    command.IconSideId,
                    command.IconAlignId,
                    command.RouteId
                    ));
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                var tourStepResult = await _tourStepsRepository.UpdateTourStepAsync(TourStep.Create(
                    command.Id,
                    command.TourId,
                    command.ElementIdentifier,
                    command.Sequence,
                    command.TooltipId,
                    command.AlignId,
                    command.SideId
                    ));
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                _unitOfWork.CommitTransaction();
                return tourStepResult;
            }
            catch (Exception)
            {
                return Errors.TourStep.UpdateFailed;
            }
        }
    }
}
