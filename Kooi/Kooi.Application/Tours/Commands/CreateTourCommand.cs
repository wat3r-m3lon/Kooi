using ErrorOr;
using MediatR;

namespace Kooi.Application.Tours.Commands
{
    public sealed record CreateTourCommand(
        string Name,
        Guid RouteId,
        bool Required,
        Guid UserId
        ) : IRequest<ErrorOr<Guid>>;
}
