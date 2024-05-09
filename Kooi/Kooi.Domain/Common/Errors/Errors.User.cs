using ErrorOr;

namespace Kooi.Domain.Common.Errors
{
   public static partial class Errors
    {
        public static class User
        {
            public static Error EmailInvalid => Error.Validation(code: "User.ExistingEmail", description: "This email is invalid");
            public static Error PasswordInvalid => Error.Validation(code: "User.PasswordInvalid", description: "Password must be at least 6 characters long.");
            public static Error CreationFailed => Error.Validation(code: "User.CreationFailed", description: "User creation Failed");
            public static Error UserNotFound => Error.Validation(code: "User.UserNotFound", description: "User is not found");
        }
      
    }
}
