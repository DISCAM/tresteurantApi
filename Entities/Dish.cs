namespace restaurantAPI.Entities
{
    public class Dish
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public string? Description { get; set; }

        // W finansach zwykle i tak ustawiasz precyzję w konfiguracji EF (poniżej)
        public decimal Price { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;


    }
}
