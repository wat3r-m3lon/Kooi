using ErrorOr;

namespace Kooi.Domain.Common.Errors
{
   public static partial class Errors
    {
        public static class Tour
        {
            public static Error CreationFailed => Error.Validation(code: "Tour.CreationFailed", description: "Tour creation Failed");
            public static Error TourNotFound => Error.Validation(code: "Tour.TourNotFound", description: "Tour is not found");
        }
      
    }
}
