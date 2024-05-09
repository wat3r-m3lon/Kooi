using ErrorOr;
using Kooi.Domain.Models.Tooltips;

namespace Kooi.Domain.Repositories
{
    public interface ITooltipInstructionsRepository
    {
        Task<Guid> CreateTooltipInstructionAsync(TooltipInstruction instruction);
        Task<bool> UpdateTooltipInstructionAsync(TooltipInstruction instruction);
        Task<ErrorOr<TooltipInstruction>> GetInstructionByTooltipIdAsync(Guid id);
    }
}
