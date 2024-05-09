using ErrorOr;
using MediatR;

namespace Kooi.Application.Tooltips.Commands
{
    public sealed record CreateTooltipCommand(
           string Title,
           Guid ContentTypeId,
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
           ) : IRequest<ErrorOr<Guid>>;
}
