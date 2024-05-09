using ErrorOr;
using Kooi.Domain.Models.Users;

namespace Kooi.Domain.Repositories
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string firebaseId);
        Task<ErrorOr<Guid>> CreateUserAsync(User user);
    }
}
