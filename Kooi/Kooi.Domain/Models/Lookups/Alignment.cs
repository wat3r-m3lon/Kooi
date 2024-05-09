
namespace Kooi.Domain.Models.Lookups
{
    public class Alignment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static Alignment Create(string name)
        {
            return new Alignment { Name = name };
        }
    }
}
