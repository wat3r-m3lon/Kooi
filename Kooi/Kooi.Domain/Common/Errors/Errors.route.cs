using ErrorOr;

namespace Kooi.Domain.Common.Errors
{
   public static partial class Errors
    {
        public static class Route
        {
            public static Error CreationFailed => Error.Validation(code: "Route.CreationFailed", description: "Route creation Failed");
            public static Error RouteNotFound => Error.Validation(code: "Route.RouteNotFound", description: "Route is not found");
        }
      
    }
}
