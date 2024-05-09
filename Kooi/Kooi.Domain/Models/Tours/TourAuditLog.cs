
using System.ComponentModel.DataAnnotations;

namespace Kooi.Domain.Models.Tours
{
    public class TourAuditLog
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TourId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateViewed { get; set; }
        public bool Completed { get; set; }

        public static TourAuditLog Create(Guid TourId, Guid UserId, DateTime DateViewed, bool Completed)
        {
            return new TourAuditLog
            {
                TourId = TourId,
                UserId = UserId,
                DateViewed = DateViewed,
                Completed = Completed
            };
        }
    }
}
