using AutoMapper;
using Microsoft.EntityFrameworkCore;
using restaurantAPI.Entities;
using restaurantAPI.Models;

namespace restaurantAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly ResteurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public RestaurantService(ResteurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool Update(int id, UpdateRestaurantDto dto)
        {
            var restaurant = _dbContext
                   .Restaurants
                   .FirstOrDefault(x => x.Id == id);
            if (restaurant is null) return false;

            //restaurant.Name = dto.Name;
            //restaurant.Description = dto.Description;
            //restaurant.HasDelivery = dto.HasDelivery;

            _mapper.Map(dto, restaurant);

            _dbContext.SaveChanges();

            return true;

        }

        public bool Delete(int id)
        {
            var restaurant = _dbContext
                    .Restaurants
                    .FirstOrDefault(x => x.Id == id);
            if (restaurant is null) return false;
            _dbContext.Restaurants.Remove(restaurant);
            _dbContext.SaveChanges();

            return true;
        }

        public RestaurantDto GetById(int id)
        {
            ///var restaurants = _dbContext.Restaurants.Where(x => x.Id == id).FirstOrDefault();
            var restaurant = _dbContext
                .Restaurants
                .Include(x => x.Address)
                .Include(x => x.Dishes)
                .FirstOrDefault(x => x.Id == id);

            if (restaurant is null) return null;

            var result = _mapper.Map<RestaurantDto>(restaurant);
            return result;
        }

        public IEnumerable<RestaurantDto> GetAll()
        {
            var restaurants = _dbContext
               .Restaurants
               .Include(x => x.Address)
               .Include(x => x.Dishes)
               .ToList();

            // starta metoda mapowania 

            //var restaurantDtos = restaurants.Select(x => new RestaurantDto()
            //{
            //    Name = x.Name,
            //    Category = x.Category,
            //    City = x.Address.City
            //});

            var restaurantDtos = _mapper.Map<List<RestaurantDto>>(restaurants);

            return restaurantDtos;
        }

        public int Create(CreateRestaurantDto dto)
        {

            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();

            return restaurant.Id;
        }


    }
}
