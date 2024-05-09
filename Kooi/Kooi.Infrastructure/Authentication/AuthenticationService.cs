using Kooi.Application.Abstractions.Authentication;
using FirebaseAdmin.Auth;
using ErrorOr;
using Kooi.Application.Users.Authentication.Commands;
using Kooi.Domain.Common.Errors;

namespace Infrastructure.Authentication
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        
        public async Task<ErrorOr<AuthenticationResult>> RegisterAsync(string email, string password)
        {
            try
            {
                var userArgs = new UserRecordArgs { Email = email, Password = password };
                var userRecord = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);
                return new AuthenticationResult(userRecord.Uid);
            }
            catch (FirebaseAuthException)
            {
                return Errors.User.EmailInvalid;
            }
            catch (System.ArgumentException)
            {
                return Errors.User.PasswordInvalid;
            }
        }
       
    }
}
