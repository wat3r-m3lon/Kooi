
using System.ComponentModel.DataAnnotations;

namespace Kooi.Domain.Models.Tours
{
    public class TourStep
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TourId { get; set; }
        public string? ElementIdentifier { get; set; }
        public int Sequence { get; set; }
        public Guid TooltipId { get; set; }
        public Guid AlignId { get; set; }
        public Guid SideId { get; set; }

        public static TourStep Create(Guid TourId, string ElementIdentifier, int Sequence, Guid TooltipId, Guid AlignId, Guid SideId)
        {
            return new TourStep
            {
                TourId = TourId,
                ElementIdentifier = ElementIdentifier,
                Sequence = Sequence,
                TooltipId = TooltipId,
                AlignId = AlignId,
                SideId = SideId
            };
        }

        public static TourStep Create(Guid Id, Guid TourId, string ElementIdentifier, int Sequence, Guid TooltipId, Guid AlignId, Guid SideId)
        {
            return new TourStep
            {
                Id = Id,
                TourId = TourId,
                ElementIdentifier = ElementIdentifier,
                Sequence = Sequence,
                TooltipId = TooltipId,
                AlignId = AlignId,
                SideId = SideId
            };
        }
    }
}
