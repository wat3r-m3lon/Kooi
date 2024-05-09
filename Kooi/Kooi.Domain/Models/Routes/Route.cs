

using System.ComponentModel.DataAnnotations;

namespace Kooi.Domain.Models.Routes
{
    public class Route
    {
        [Key]
        public Guid Id { get; set; }
        public string? Uri { get; set; }

        public static Route Create(string uri)
        {
            return new Route {Uri = uri };
        }
    }
}
