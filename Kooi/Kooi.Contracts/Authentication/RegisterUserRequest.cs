namespace Kooi.Contracts.Authentication
{
    public record RegisterUserRequest(
          string Fullname,
           string Email,
           string Password,
          System.Guid RoleId,
          string NetworkId

     );
}
