using Kooi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Kooi.Domain.Models.Users;
using Kooi.Domain.Common.Errors;
using ErrorOr;

namespace Persistence.Repositories
{
    internal class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;

        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ErrorOr<Guid>> CreateUserAsync(User user)
        {
            _context.Add<User>(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Errors.User.CreationFailed;
            }
            return user.Id;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string Id)
        {
            return await _context.Users.SingleAsync(u => u.Id.Equals(Id));
        }

    }
}
