using System.ComponentModel.DataAnnotations;

namespace restaurantAPI.Models
{
    public class CreateRestaurantDto
    {
        [Required]
        [MaxLength(25, ErrorMessage = "Nazwa restauracji może mieć maksymalnie 25 znaków.")]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public bool HasDelivery { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string? City { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Street { get; set; }
        public string? PostalCode { get; set; }

    }
}
