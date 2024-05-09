using ErrorOr;
using Kooi.Domain.Models.Lookups;
using Kooi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Kooi.Domain.Common.Errors;

namespace Kooi.Infrastructure.Persistence.Repositories
{
    internal class AlignmentsRepository : IAlignmentsRepository
    {
        private readonly ApplicationDbContext _context;
        public AlignmentsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Alignment>> GetAllAlignmentsAsync()
        {
            return await _context.Alignments.ToListAsync();
        }

        public async Task<ErrorOr<Alignment>> GetAlignmentByNameAsync(string name)
        {
            var alignment = await _context.Alignments.Where(c => c.Name == name).FirstOrDefaultAsync();
            if (alignment != null)
            {
                return alignment;
            }
            else { return Errors.Lookups.AlignmentNotFound; }
        }

        public async Task<ErrorOr<Alignment>> GetAlignmentByIdAsync(Guid id)
        {
            try
            {
                return await _context.Alignments.SingleAsync(t => t.Id == id);
            }
            catch (System.InvalidOperationException)
            {
                return Errors.Lookups.AlignmentNotFound; ;
            }
        }
    }
}
