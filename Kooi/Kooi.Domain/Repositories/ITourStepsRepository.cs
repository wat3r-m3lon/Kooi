using Kooi.Domain.Models.Tours;

namespace Kooi.Domain.Repositories
{
    public interface ITourStepsRepository
    {
        Task<Guid> CreateTourStepAsync(TourStep tourStep);
        Task<bool> UpdateTourStepAsync(TourStep tourStep);
    }
}
