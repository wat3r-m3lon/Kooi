using Kooi.Application.Data;
using Kooi.Domain.Repositories;
using MediatR;
using Kooi.Domain.Common.Errors;
using ErrorOr;
using Kooi.Domain.Models.Tooltips;
using Kooi.Domain.Models.Tours;

namespace Kooi.Application.TourSteps.Commands
{
    internal sealed class CreateTourStepCommandHandler : IRequestHandler<CreateTourStepCommand,ErrorOr<Guid>>
    {
        private readonly ITourStepsRepository _tourStepsRepository;
        private readonly ITooltipsRepository _tooltipsRepository;
        private readonly ITooltipInstructionsRepository _tooltipInstructionsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTourStepCommandHandler(
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

        public async Task<ErrorOr<Guid>> Handle(CreateTourStepCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var tooltipResult = await _tooltipsRepository.CreateTooltipAsync(Tooltip.Create(
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
                var instructionResult = await _tooltipInstructionsRepository.CreateTooltipInstructionAsync(TooltipInstruction.Create(
                    command.ElementIdentifier,
                    tooltipResult,
                    command.IconId,
                    command.IconSideId,
                    command.IconAlignId,
                    command.RouteId
                    ));
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                var tourStepResult = await _tourStepsRepository.CreateTourStepAsync(TourStep.Create(
                    command.TourId,
                    command.ElementIdentifier,
                    command.Sequence,
                    tooltipResult,
                    command.AlignId,
                    command.SideId
                    ));
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                _unitOfWork.CommitTransaction();
                return tourStepResult;
            }
            catch (Exception)
            {
                return Errors.TourStep.CreationFailed;
            }
        }
    }
}
