namespace restaurantAPI.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public bool HasDelivery { get; set; }

        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }

        // 1:1
        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;

        // 1:many
        public List<Dish> Dishes { get; set; } = new();
    }

}
