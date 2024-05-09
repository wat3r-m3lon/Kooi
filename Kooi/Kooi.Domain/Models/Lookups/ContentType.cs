
namespace Kooi.Domain.Models.Lookups
{
    public class ContentType
    {
        public Guid Id { get; set; }
        public string Type { get; set; }

        public static ContentType Create(string type) 
        {
            return new ContentType { Type = type };
        }
    }
}
