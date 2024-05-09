using ErrorOr;
using Kooi.Domain.Models.Lookups;
using Kooi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Kooi.Domain.Common.Errors;

namespace Kooi.Infrastructure.Persistence.Repositories
{
    internal class SidesRepository : ISidesRepository
    {
        private readonly ApplicationDbContext _context;
        public SidesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Side>> GetAllSidesAsync()
        {
            return await _context.Sides.ToListAsync();
        }

        public async Task<ErrorOr<Side>> GetSideByNameAsync(string name)
        {
            var side = await _context.Sides.Where(c => c.Name == name).FirstOrDefaultAsync();
            if (side != null)
            {
                return side;
            }
            else { return Errors.Lookups.SideNotFound; }
        }

        public async Task<ErrorOr<Side>> GetSideByIdAsync(Guid id)
        {
            try
            {
                return await _context.Sides.SingleAsync(t => t.Id == id);
            }
            catch (System.InvalidOperationException)
            {
                return Errors.Lookups.SideNotFound;
            }
        }
    }
}
