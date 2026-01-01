using restaurantAPI.Entities;

namespace restaurantAPI.Models
{
    public class DishDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public string? Description { get; set; }

        // W finansach zwykle i tak ustawiasz precyzję w konfiguracji EF (poniżej)
        public decimal Price { get; set; }


    }
}
