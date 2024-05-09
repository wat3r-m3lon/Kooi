using ErrorOr;
using Kooi.Domain.Models.Tours;

namespace Kooi.Domain.Repositories
{
    public interface ITourAuditLogRepository
    {
        Task<Guid> CreateTourAuditLogAsync(TourAuditLog tourAuditLog);
    }
}
