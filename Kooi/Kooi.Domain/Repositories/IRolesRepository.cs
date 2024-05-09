using ErrorOr;
using Kooi.Domain.Models.Lookups;

namespace Kooi.Domain.Repositories
{
    public interface IRolesRepository
    {
        Task<List<Role>> GetAllRolesAsync();
        Task<ErrorOr<Role>> GetRoleByNameAsync(string name);
        Task<ErrorOr<Role>> GetRoleByIdAsync(Guid id);
    }
}
