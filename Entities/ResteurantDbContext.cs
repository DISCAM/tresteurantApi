using Microsoft.EntityFrameworkCore;

namespace restaurantAPI.Entities
{
    public class ResteurantDbContext : DbContext
    {
        public ResteurantDbContext(DbContextOptions<ResteurantDbContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(25);
            
            modelBuilder.Entity<Dish>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(25);
            
            modelBuilder.Entity<Dish>()
                .Property(x => x.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Address>()
                .Property(x => x.City)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(50);

            // 1:1 Restaurant -> Address (FK po stronie Restaurant: AddressId)
            modelBuilder.Entity<Restaurant>()
                .HasOne(x => x.Address)
                .WithOne(x => x.Restaurant)
                .HasForeignKey<Restaurant>(r => r.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1:many Restaurant -> Dishes
            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne(x => x.Restaurant)
                .HasForeignKey(x => x.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);


        }

        




    }
}
