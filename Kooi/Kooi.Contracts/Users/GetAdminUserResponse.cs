

namespace Kooi.Contracts.Users
{
    public record GetAdminUserResponse(
        System.Guid Id,
        string Email,
        string FirebaseId,
        System.Guid UserId,
        System.Guid RoleId,
        string Fullname
    );
}
