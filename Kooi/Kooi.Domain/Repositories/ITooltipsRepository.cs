using ErrorOr;
using Kooi.Domain.Models.Tooltips;
using static Kooi.Domain.Common.Errors.Errors;

namespace Kooi.Domain.Repositories
{
    public interface ITooltipsRepository
    {
        Task<ErrorOr<Models.Tooltips.Tooltip>> GetTooltipByIdAsync(Guid id);
        Task<List<Models.Tooltips.Tooltip>> GetAllTooltipsAsync();
        Task<List<Models.Tooltips.Tooltip>> GetTooltipsByContentIdAsync(string id);
        Task<Guid> CreateTooltipAsync(Models.Tooltips.Tooltip tooltip);
        Task<bool> UpdateTooltipAsync(Models.Tooltips.Tooltip tooltip);

    }
}
