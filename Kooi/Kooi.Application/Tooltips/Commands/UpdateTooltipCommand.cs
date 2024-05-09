using ErrorOr;
using MediatR;

namespace Kooi.Application.Tooltips.Commands
{
    public sealed record UpdateTooltipCommand(
           Guid Id,
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
        ) : IRequest<ErrorOr<bool>>;
}
