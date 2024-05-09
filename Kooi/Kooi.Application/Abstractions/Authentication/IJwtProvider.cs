using ErrorOr;
using Kooi.Application.Users.Authentication.Commands;

namespace Kooi.Application.Abstractions.Authentication
{
    public interface IJwtProvider
    {
        Task<ErrorOr<AuthenticationResult>> GetCredentialsAsync(string email, string password);
    }
}
