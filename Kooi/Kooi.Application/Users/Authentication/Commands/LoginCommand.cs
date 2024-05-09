using ErrorOr;
using MediatR;

namespace Kooi.Application.Users.Authentication.Commands
{
    public record LoginCommand(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
    
}
