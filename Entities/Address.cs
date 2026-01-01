namespace restaurantAPI.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public required string City { get; set; }
        public required string Street { get; set; }
        public required string PostalCode { get; set; }

        // 1:1 — nawigacja zwrotna (opcjonalna z punktu widzenia encji)
        public Restaurant? Restaurant { get; set; }


    }
}
