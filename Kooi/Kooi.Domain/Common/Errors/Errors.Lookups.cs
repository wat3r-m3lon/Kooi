using ErrorOr;

namespace Kooi.Domain.Common.Errors
{
   public static partial class Errors
    {
        public static class Lookups
        {
            public static Error ContentTypeNotFound => Error.Validation(code: "Lookups.ContentTypeNotFound", description: "Content type is not found");
            public static Error AlignmentNotFound => Error.Validation(code: "Lookups.AlignmentNotFound", description: "Alignment is not found");
            public static Error RoleNotFound => Error.Validation(code: "Lookups.RoleNotFound", description: "Role is not found");
            public static Error SideNotFound => Error.Validation(code: "Lookups.SideNotFound", description: "Side is not found");
        }
      
    }
}

