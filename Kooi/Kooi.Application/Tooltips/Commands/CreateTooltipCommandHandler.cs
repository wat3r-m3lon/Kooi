using ErrorOr;
using Kooi.Application.Data;
using Kooi.Domain.Models.Tooltips;
using Kooi.Domain.Repositories;
using MediatR;
using Kooi.Domain.Common.Errors;

namespace Kooi.Application.Tooltips.Commands
{
    internal sealed class CreateTooltipCommandHandler : IRequestHandler<CreateTooltipCommand, ErrorOr<Guid>>
    {

        private readonly ITooltipsRepository _tooltipsRepository;
        private readonly ITooltipInstructionsRepository _tooltipInstructionsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTooltipCommandHandler(
            ITooltipsRepository tooltipsRepository, 
            ITooltipInstructionsRepository tooltipInstructionsRepository, 
            IUnitOfWork unitOfWork)
        {

            _tooltipsRepository = tooltipsRepository;
            _tooltipInstructionsRepository = tooltipInstructionsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Guid>> Handle(CreateTooltipCommand command, CancellationToken cancellationToken)
        {

            try
            {
                _unitOfWork.BeginTransaction();
                var tooltipResult = await _tooltipsRepository.CreateTooltipAsync(Tooltip.Create(
                    command.Title,
                    command.ContentTypeId,
                    command.Description,
                    command.ShowProgress,
                    command.ProgressText,
                    command.NextBtnText,
                    command.PrevBtnText,
                    command.DoneBtnText
                    ));
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                var result = await _tooltipInstructionsRepository.CreateTooltipInstructionAsync(TooltipInstruction.Create(
                    command.ElementIdentifier,
                    tooltipResult,
                    command.IconId,
                    command.IconSideId,
                    command.IconAlignId,
                    command.RouteId
                    ));
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                //throw new Exception();//test rollback
                _unitOfWork.CommitTransaction();
                return tooltipResult;
            }
            catch (Exception)
            {
                return Errors.Tooltip.CreationFail;
            }
        }
    }
}
