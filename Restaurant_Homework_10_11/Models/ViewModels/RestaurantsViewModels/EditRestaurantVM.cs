using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantMVCViewer.Models.DTO;

namespace RestaurantMVCViewer.Models.ViewModels.RestaurantsViewModels
{
    public class EditRestaurantVM
    {
        public RestaurantDTO Restaurant { get; set; } = default!;

        public IFormFile? Image { get; set; }
        public SelectList? DishSL { get; set; }
    }
}
