namespace Kooi.Contracts.Authentication
{
    public record LoginUserRequest(
         string Email,
         string Password
    );
}
