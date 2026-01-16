using AutoMapper;
using restaurantAPI.Entities;
using restaurantAPI.Models;

namespace restaurantAPI
{
    public class RestaurantsMappingProfile : Profile
    {
        public RestaurantsMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Dish, DishDto>();

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(x => x.Address, a => a.MapFrom(dto => new Address()
                { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street } ));

            CreateMap<UpdateRestaurantDto, Restaurant>();

            CreateMap<CreateDishDto, Dish>();

            //CreateMap<CreateDishDto, Dish>()
            //    .ForMember(d => d.RestaurantId, opt => opt.Ignore());
        }
    }
}
