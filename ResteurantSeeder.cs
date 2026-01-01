using restaurantAPI.Entities;

namespace restaurantAPI
{
    public class ResteurantSeeder
    {
        private readonly ResteurantDbContext _dbContext;

        public ResteurantSeeder(ResteurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {

                foreach (var r in GetRestaurants())
                {
                    if (!_dbContext.Restaurants.Any(x => x.Name == r.Name))
                        _dbContext.Restaurants.Add(r);
                }
                _dbContext.SaveChanges();

                
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var resteurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC2",
                    Description = "American Fast food KFC Kentucky Fried Chicken",
                    ContactEmail = "kfc@kfc.com",
                    HasDelivery =true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Description = "hot wings",
                            Price = 10.24M
                        },
                        new Dish()
                        {
                            Name = "Hot Chicken wings",
                            Description = "Hot hot wings",
                            Price = 5.24M

                        }
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa",
                        PostalCode = "30-000"
                    }
                    

                },
                new Restaurant()
                {
                    Name = "McDonald2",
                    Description = "American Fast food MD",
                    ContactEmail = "md@md.com",
                    HasDelivery = false,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Cheeseburger",
                            Description = "burger",
                            Price = 2.24M
                        },
                        new Dish()
                        {
                            Name = "Hot Chicken MC",
                            Description = "Hot wings",
                            Price = 5.24M

                        }
                    },
                    Address = new Address()
                    {
                        City = "Warszawa",
                        Street = "Lwowska",
                        PostalCode = "40-000"
                    }


                },
                new Restaurant()
                {
                    Name = "Cegielnia2",
                    Description = "Resteuracja Cegielnia Nowy Sącz",
                    ContactEmail = "cegielnia@cegielnia.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Pizza margherita",
                            Description = "hot pizza",
                            Price = 20.24M
                        },
                        new Dish()
                        {
                            Name = "Wrap chicken",
                            Description = "wrap",
                            Price = 7.24M

                        }
                    },
                    Address = new Address()
                    {
                        City = "Nowy Sącz",
                        Street = "Nawojowa",
                        PostalCode = "33-300"
                    }


                }

            };

            return resteurants;
          
                
           
        
        }

    }
}
