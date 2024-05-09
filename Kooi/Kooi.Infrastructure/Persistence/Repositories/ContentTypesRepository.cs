using ErrorOr;
using Kooi.Domain.Models.Lookups;
using Kooi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Kooi.Domain.Common.Errors;

namespace Kooi.Infrastructure.Persistence.Repositories
{
    internal class ContentTypesRepository : IContentTypesRepository
    {
        private readonly ApplicationDbContext _context;
        public ContentTypesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContentType>> GetAllContentTypesAsync()
        {
            return await _context.ContentTypes.ToListAsync();
        }

        public async Task<ErrorOr<ContentType>> GetContentTypeByTypeAsync(string type)
        {
            var contentType = await _context.ContentTypes.Where(c => c.Type == type).FirstOrDefaultAsync();
            if (contentType != null)
            {
                return contentType;
            }
            else { return Errors.Lookups.ContentTypeNotFound; }
        }

        public async Task<ErrorOr<ContentType>> GetContentTypeByIdAsync(Guid id)
        {
            try
            {
                return await _context.ContentTypes.SingleAsync(t => t.Id == id);
            }
            catch (System.InvalidOperationException)
            {
                return Errors.Lookups.ContentTypeNotFound;
            }
        }
    }
}
