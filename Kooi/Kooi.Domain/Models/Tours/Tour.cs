using System.ComponentModel.DataAnnotations;

namespace Kooi.Domain.Models.Tours
{
    public class Tour
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid RouteId { get; set; }
        public bool Required { get; set; }
        public static Tour Create(string Name, Guid RouteId, bool Required)
        {
            return new Tour
            {
                Name = Name,
                RouteId = RouteId,
                Required = Required
            };
        }
    }

    
}
