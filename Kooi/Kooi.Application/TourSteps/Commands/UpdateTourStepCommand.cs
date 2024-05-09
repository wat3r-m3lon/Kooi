
using ErrorOr;
using MediatR;

namespace Kooi.Application.TourSteps.Commands
{
    public sealed record UpdateTourStepCommand(
        Guid Id,
        Guid TourId,
        int Sequence,
        Guid TooltipId,
        Guid AlignId,
        Guid SideId,
        string Title,
        Guid ContenTtypeId,
        string Description,
        bool ShowProgress,
        string ProgressText,
        string NextBtnText,
        string PrevBtnText,
        string DoneBtnText,
        string ElementIdentifier,
        Guid IconId,
        Guid IconSideId,
        Guid IconAlignId,
        Guid RouteId
        ) :IRequest<ErrorOr<bool>>;
}
