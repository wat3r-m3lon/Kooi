
namespace Kooi.Domain.Models.Lookups
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static Role Create(string name)
        {
            return new Role { Name = name };
        }
    }
}
