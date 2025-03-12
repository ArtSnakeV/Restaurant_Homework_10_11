using AutoMapper;
using RestaurantMVCViewer.Data.Entities;
using RestaurantMVCViewer.Models.DTO;

namespace RestaurantMVCViewer.AutoMapperProfiles
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantDTO>().ReverseMap();
        }
    }
}
