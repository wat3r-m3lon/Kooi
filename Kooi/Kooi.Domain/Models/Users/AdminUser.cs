

namespace Kooi.Domain.Models.Users
{
    
    public class AdminUser 
    {

   
        public System.Guid Id { get; set; }
        public string Email { get; set; }
        public string FirebaseId { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid RoleId { get; set; }
        public string Fullname { get; set; }

        public static AdminUser Create(string email, string firebaseId, Guid userId, Guid roleId, string fullname)
        {
            return new AdminUser
            {
                Email = email,
                FirebaseId = firebaseId,
                UserId = userId,
                RoleId = roleId,
                Fullname = fullname
            };
        }
    }
}
