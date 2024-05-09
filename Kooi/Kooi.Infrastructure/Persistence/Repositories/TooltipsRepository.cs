using ErrorOr;
using Kooi.Domain.Common.Errors;
using Kooi.Domain.Models.Tooltips;
using Kooi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using static Kooi.Domain.Common.Errors.Errors;

namespace Kooi.Infrastructure.Persistence.Repositories
{
    internal class TooltipsRepository : ITooltipsRepository
    {

        private readonly ApplicationDbContext _context;

        public TooltipsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateTooltipAsync(Domain.Models.Tooltips.Tooltip tooltip)
        {
            await _context.AddAsync<Domain.Models.Tooltips.Tooltip>(tooltip);
            return tooltip.Id;
        }
      
        public async Task<List<Domain.Models.Tooltips.Tooltip>> GetAllTooltipsAsync()
        {
   
            return await _context.Tooltips.ToListAsync();

        }

        public async Task<ErrorOr<Domain.Models.Tooltips.Tooltip>> GetTooltipByIdAsync(Guid id)
        {
            try
            {
                return await _context.Tooltips.SingleAsync(t => t.Id == id);
            }
            catch (System.InvalidOperationException) 
            {
                return Errors.Tooltip.NotFound;
            }
        }

        public async Task<List<Domain.Models.Tooltips.Tooltip>> GetTooltipsByContentIdAsync(string id)
        {
            return await _context.Tooltips
                .Where(x => x.ContentTypeId.ToString().Equals(id)).ToListAsync();
        }

        public async Task<bool> UpdateTooltipAsync(Domain.Models.Tooltips.Tooltip tooltip)
        {
            var entity = await _context.FindAsync<Domain.Models.Tooltips.Tooltip>(tooltip.Id);
            if (entity == null)
            {
                return false;
            }
            _context.Entry(entity).CurrentValues.SetValues(tooltip);
            return true;
        }
    }
}
