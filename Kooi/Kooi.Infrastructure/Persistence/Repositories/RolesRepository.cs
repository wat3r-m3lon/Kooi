using ErrorOr;
using Kooi.Domain.Models.Lookups;
using Kooi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Kooi.Domain.Common.Errors;

namespace Kooi.Infrastructure.Persistence.Repositories
{
    internal class RolesRepository : IRolesRepository
    {
        private readonly ApplicationDbContext _context;
        public RolesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<ErrorOr<Role>> GetRoleByNameAsync(string name)
        {
            var role = await _context.Roles.Where(c => c.Name == name).FirstOrDefaultAsync();
            if (role != null)
            {
                return role;
            }
            else { return Errors.Lookups.RoleNotFound; }
        }

        public async Task<ErrorOr<Role>> GetRoleByIdAsync(Guid id)
        {
            try
            {
                return await _context.Roles.SingleAsync(t => t.Id == id);
            }
            catch (System.InvalidOperationException)
            {
                return Errors.Lookups.RoleNotFound;
            }
        }
    }
}
