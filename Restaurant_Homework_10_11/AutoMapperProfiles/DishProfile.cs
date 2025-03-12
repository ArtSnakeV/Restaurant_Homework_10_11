using AutoMapper;
using RestaurantMVCViewer.Data.Entities;
using RestaurantMVCViewer.Models.DTO;

namespace RestaurantMVCViewer.AutoMapperProfiles
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishDTO>().ReverseMap();
        }
    }
}
