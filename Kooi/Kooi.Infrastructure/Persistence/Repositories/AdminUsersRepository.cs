using Kooi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Kooi.Domain.Models.Users;
using ErrorOr;
using Kooi.Domain.Common.Errors;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Persistence.Repositories
{
    internal class AdminUsersRepository : IAdminUsersRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminUsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ErrorOr<string>> CreateAdminUserAsync(AdminUser user)
        {
            _context.Add<AdminUser>(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Errors.User.CreationFailed;
            }
            return user.FirebaseId;
        }

        public async Task<List<AdminUser>> GetAllAdminUsersAsync()
        {
            return await _context.AdminUsers.ToListAsync();
        }

        public async Task<ErrorOr<AdminUser>> GetAdminUserByIdAsync(string firebaseId)
        {
            try
            {
                return await _context.AdminUsers.SingleAsync(u => u.FirebaseId.Equals(firebaseId));
            }
            catch (System.InvalidOperationException)
            {
                return Errors.User.UserNotFound;
            }

        }

        public async Task<bool> AdminUserEmailExistsAsync(string email)
        {

            try
            {
                var dbEntry = await _context.AdminUsers.FirstAsync(user => user.Email == email);
                return true;//email exist
            }
            catch (System.InvalidOperationException)
            {
                return false;//cannot find this email
            }
            
        }
    }
}
