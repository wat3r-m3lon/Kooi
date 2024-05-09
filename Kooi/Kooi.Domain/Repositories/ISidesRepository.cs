using ErrorOr;
using Kooi.Domain.Models.Lookups;

namespace Kooi.Domain.Repositories
{
    public interface ISidesRepository
    {
        Task<List<Side>> GetAllSidesAsync();
        Task<ErrorOr<Side>> GetSideByNameAsync(string name);
        Task<ErrorOr<Side>> GetSideByIdAsync(Guid id);
    }
}
