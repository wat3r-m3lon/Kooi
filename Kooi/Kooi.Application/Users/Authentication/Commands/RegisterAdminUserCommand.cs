using ErrorOr;
using MediatR;

namespace Kooi.Application.Users.Authentication.Commands
{
    public sealed record RegisterAdminUserCommand(
           string Fullname,
           string Email,
           string Password,
           System.Guid RoleId,
           string NetwrokId
           ) : IRequest<ErrorOr<AuthenticationResult>>;
}
