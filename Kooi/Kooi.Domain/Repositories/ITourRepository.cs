using ErrorOr;
using Kooi.Domain.Models.Tours;

namespace Kooi.Domain.Repositories
{
    public interface ITourRepository
    {
        Task<Guid> CreateTourAsync(Tour tour);
    }
}
