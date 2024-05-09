
namespace Kooi.Domain.Models.Lookups
{
    public class Side
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static Side Create(string name)
        {
            return new Side { Name = name };
        }
    }
}
