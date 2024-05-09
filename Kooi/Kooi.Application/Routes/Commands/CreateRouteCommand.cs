using ErrorOr;
using MediatR;

namespace Kooi.Application.Routes.Commands
{
    public sealed record CreateRouteCommand(
        string Uri
        ) : IRequest<ErrorOr<Guid>>;
}
