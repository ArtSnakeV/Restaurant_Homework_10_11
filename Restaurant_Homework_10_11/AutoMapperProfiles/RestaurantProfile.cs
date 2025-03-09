using AutoMapper;
using Restaurant_Homework_10_11.Data.Entities;
using Restaurant_Homework_10_11.Models.DTO;

namespace Restaurant_Homework_10_11.AutoMapperProfiles
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantDTO>().ReverseMap();
        }
    }
}
