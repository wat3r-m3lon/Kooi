
namespace Kooi.Contracts.Tours
{
    public record CreateTourStepRequest(
        Guid TourId,
        int Sequence,
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
    );
}
