
using Kooi.Domain.Models.Tours;
using Kooi.Domain.Repositories;
using Persistence;

namespace Kooi.Infrastructure.Persistence.Repositories
{
    internal class TourAuditLogRepository : ITourAuditLogRepository
    {
        ApplicationDbContext _context;
        public TourAuditLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateTourAuditLogAsync(TourAuditLog tourAuditLog)
        {

            await _context.AddAsync<TourAuditLog>(tourAuditLog);
            return tourAuditLog.Id;

        }
    }
}
