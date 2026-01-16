using System.ComponentModel.DataAnnotations;

namespace restaurantAPI.Models
{
    public class CreateDishDto
    {
        [Required]
        [MaxLength(25)]
        public required string Name { get; set; }
        public string? Description { get; set; }

        // W finansach zwykle i tak ustawiasz precyzję w konfiguracji EF (poniżej)
        [Range(0.01, 999999)]
        public decimal Price { get; set; }

        //public int RestaurantId { get; set; }
    }
}
