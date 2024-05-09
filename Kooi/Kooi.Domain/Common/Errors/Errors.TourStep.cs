using ErrorOr;

namespace Kooi.Domain.Common.Errors
{
   public static partial class Errors
    {
        public static class TourStep
        {
            public static Error CreationFailed => Error.Validation(code: "TourStep.CreationFailed", description: "TourStep creation Failed");
            public static Error UpdateFailed => Error.Validation(code: "TourStep.UpdateFailed", description: "TourStep update Failed");
            public static Error TourNotFound => Error.Validation(code: "TourStep.TourNotFound", description: "TourStep is not found");
        }
      
    }
}
