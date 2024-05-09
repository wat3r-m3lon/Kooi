using ErrorOr;
using Kooi.Domain.Models.Lookups;

namespace Kooi.Domain.Repositories
{
    public interface IContentTypesRepository
    {
        Task<List<ContentType>> GetAllContentTypesAsync();
        Task<ErrorOr<ContentType>> GetContentTypeByTypeAsync(string type);
        Task<ErrorOr<ContentType>> GetContentTypeByIdAsync(Guid id);
    }
}
