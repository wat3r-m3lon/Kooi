using Kooi.Domain.Models.Tours;
using Kooi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Kooi.Domain.Common.Errors;

namespace Kooi.Infrastructure.Persistence.Repositories
{
    internal class TourRepository : ITourRepository
    {
        private readonly ApplicationDbContext _context;
        public TourRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateTourAsync(Tour tour)
        {
            await _context.AddAsync<Tour>(tour);
            return tour.Id;
        }
    }
}
