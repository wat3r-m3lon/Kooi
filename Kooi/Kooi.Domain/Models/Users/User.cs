
using System.ComponentModel.DataAnnotations;

namespace Kooi.Domain.Models.Users
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string? NetworkId { get; set; }
        public DateTime FirstActive { get; set; }
        public DateTime LastActive { get; set; }


        public static User Create(string networkId, DateTime firstActive, DateTime lastActive)
        {
            return new User
            {
                NetworkId = networkId,
                FirstActive = firstActive,
                LastActive = lastActive
            };
           
        }
       
    }
}
