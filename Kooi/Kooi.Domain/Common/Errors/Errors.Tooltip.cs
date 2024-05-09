using ErrorOr;

namespace Kooi.Domain.Common.Errors
{
   public static partial class Errors
    {
        public static class Tooltip
        {
            public static Error CreationFail => Error.Validation(code: "Tooltip.CreationFail", description: "Cannot create the tooltip");
            public static Error UpdateFail => Error.Validation(code: "Tooltip.UpdateFail", description: "Cannot update the tooltip");
            public static Error NotFound => Error.Validation(code: "Tooltip.NotFound", description: "Cannot find the tooltip");
            public static Error InstructionNotFound => Error.Validation(code: "Tooltip.InstructionNotFound", description: "Cannot find the tooltip instruction");
            
        }
      
    }
}
