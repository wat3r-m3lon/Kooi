

namespace Kooi.Contracts.Tours
{
    public record CreateTourRequest(
        string Name,
        Guid RouteId,
        bool Required,
        Guid UserId
        );
}
