using ErrorOr;
using Kooi.Domain.Models.Users;
using System.Globalization;

namespace Kooi.Domain.Repositories
{
    public interface IAdminUsersRepository
    {
        Task<List<AdminUser>> GetAllAdminUsersAsync();
        Task<ErrorOr<AdminUser>> GetAdminUserByIdAsync(string firebaseId);
        Task<ErrorOr<string>> CreateAdminUserAsync(AdminUser adminUser);
        Task<bool> AdminUserEmailExistsAsync(string email);
    }
}
