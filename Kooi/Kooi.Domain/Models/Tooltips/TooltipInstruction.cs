
namespace Kooi.Domain.Models.Tooltips
{
    public class TooltipInstruction
    {
        public Guid Id { get; set; }
        public string ElementIdentifier { get; set; }
        public Guid TooltipId { get; set; }
        public Guid IconId { get; set; }
        public Guid IconSideId { get; set; }
        public Guid IconAlignId { get; set; }
        public Guid RouteId { get; set; }

        public static TooltipInstruction Create(
            string ElementIdentifier,
            Guid TooltipId,
            Guid IconId,
            Guid IconSideId,
            Guid IconAlignId,
            Guid RouteId
            )
        {
            return new TooltipInstruction
            {
                ElementIdentifier = ElementIdentifier,
                TooltipId = TooltipId,
                IconId = IconId,
                IconSideId = IconSideId,
                IconAlignId=IconAlignId,
                RouteId = RouteId
            };
        }

        public static TooltipInstruction Create(
            Guid id,
           string ElementIdentifier,
           Guid TooltipId,
           Guid IconId,
           Guid IconSideId,
           Guid IconAlignId,
           Guid RouteId
           )
        {
            return new TooltipInstruction
            {
                Id = id,
                ElementIdentifier = ElementIdentifier,
                TooltipId = TooltipId,
                IconId = IconId,
                IconSideId = IconSideId,
                IconAlignId = IconAlignId,
                RouteId = RouteId
            };
        }
    }
}
