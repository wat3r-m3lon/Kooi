using Kooi.Domain.Models.Tours;
using Kooi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Kooi.Infrastructure.Persistence.Repositories
{
    internal class TourStepsRepository : ITourStepsRepository
    {
        ApplicationDbContext _context;
        public TourStepsRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<Guid> CreateTourStepAsync(TourStep tourStep)
        {
            await _context.AddAsync<TourStep>(tourStep);
            return tourStep.Id; 
        }

        public async Task<bool> UpdateTourStepAsync(TourStep tourStep)
        {
            var entity = await _context.FindAsync<TourStep>(tourStep.Id);
            if (entity == null)
            {
                return false;
            }
            _context.Entry(entity).CurrentValues.SetValues(tourStep);
            return true;
        }
    }
}
