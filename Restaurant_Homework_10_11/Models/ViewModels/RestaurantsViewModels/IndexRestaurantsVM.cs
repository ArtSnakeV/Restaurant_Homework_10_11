using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant_Homework_10_11.Data.Entities;

namespace Restaurant_Homework_10_11.Models.ViewModels.RestaurantsViewModels
{
    public class IndexRestaurantsVM
    {
        public IEnumerable<Restaurant> Restaurants { get; set; } = default!; // (!) potential error
        public SelectList DishSL { get; set; } = default!;
        public int DishId { get; set; }
        public string? Search { get; set; }
    }
}
