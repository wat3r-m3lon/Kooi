

using ErrorOr;
using Kooi.Domain.Models.Routes;

namespace Kooi.Domain.Repositories
{
    public interface IRouteRepository
    {
        Task<ErrorOr<Guid>> CreateRouteAsync(Route route);
    }
}
