using AutoMapper;
using Restaurant_Homework_10_11.Data.Entities;
using Restaurant_Homework_10_11.Models.DTO;

namespace Restaurant_Homework_10_11.AutoMapperProfiles
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishDTO>().ReverseMap();
        }
    }
}
