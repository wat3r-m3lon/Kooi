using ErrorOr;
using Kooi.Domain.Models.Lookups;

namespace Kooi.Domain.Repositories
{
    public interface IAlignmentsRepository
    {
        Task<List<Alignment>> GetAllAlignmentsAsync();
        Task<ErrorOr<Alignment>> GetAlignmentByNameAsync(string name);
        Task<ErrorOr<Alignment>> GetAlignmentByIdAsync(Guid id);
    }
}
