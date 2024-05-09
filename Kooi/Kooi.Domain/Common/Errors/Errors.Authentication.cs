using ErrorOr;

namespace Kooi.Domain.Common.Errors
{
   public static partial class Errors
    {
        public static class Authentication
        {
            public static Error LoginFailed => Error.Validation(code: "Authentication.LoginFailed", description: "The email address or password is incorrect. Please retry");
        }
    }
}
