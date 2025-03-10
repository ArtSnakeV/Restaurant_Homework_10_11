using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant_Homework_10_11.Models.DTO;

namespace Restaurant_Homework_10_11.Models.ViewModels.RestaurantsViewModels
{
    public class EditRestaurantVM
    {
        public RestaurantDTO Restaurant { get; set; } = default!;

        public IFormFile? Image { get; set; }
        public SelectList? DishSL { get; set; }
    }
}
