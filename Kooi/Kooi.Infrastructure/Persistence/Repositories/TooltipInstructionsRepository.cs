using ErrorOr;
using Kooi.Domain.Models.Tooltips;
using Kooi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Kooi.Domain.Common.Errors;


namespace Kooi.Infrastructure.Persistence.Repositories
{
    internal class TooltipInstructionsRepository : ITooltipInstructionsRepository
    {
        private readonly ApplicationDbContext _context;
        public TooltipInstructionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateTooltipInstructionAsync(TooltipInstruction instruction)
        {
            await _context.AddAsync<TooltipInstruction>(instruction);
            return instruction.Id;
        }
        public async Task<ErrorOr<TooltipInstruction>> GetInstructionByTooltipIdAsync(Guid id)
        {
            var instuction = await _context.TooltipInstructions.Where(t => t.TooltipId == id).FirstOrDefaultAsync();
            if (instuction != null)
            {
                return instuction;
            }
            else { return Errors.Tooltip.InstructionNotFound; }
        }

        public async Task<bool> UpdateTooltipInstructionAsync(TooltipInstruction instruction)
        {
            var entity = await _context.FindAsync<TooltipInstruction>(instruction.Id);
            if (entity == null)
            {
                return false;
            }
            _context.Entry(entity).CurrentValues.SetValues(instruction);
            return true;
        }
    }
}
