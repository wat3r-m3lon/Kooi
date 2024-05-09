using ErrorOr;
using Kooi.Application.Users.Authentication.Commands;

namespace Kooi.Application.Abstractions.Authentication
{
    public interface IAuthenticationService
    {
        Task<ErrorOr<AuthenticationResult>> RegisterAsync(string email, string password);
    }
}
