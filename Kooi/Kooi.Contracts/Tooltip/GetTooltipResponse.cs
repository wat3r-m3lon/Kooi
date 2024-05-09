
namespace Kooi.Contracts.Tooltip
{
    public record GetTooltipResponse(
           Guid Id,
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
        );
}
