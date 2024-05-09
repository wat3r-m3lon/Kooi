using ErrorOr;
using MediatR;

namespace Kooi.Application.Users.Authentication.Commands
{
    public sealed record CreateUserCommand(
           string NetworkId
           ) : IRequest<ErrorOr<Guid>>;
    
}
