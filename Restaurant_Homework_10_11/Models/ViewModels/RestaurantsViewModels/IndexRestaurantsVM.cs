using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantMVCViewer.Data.Entities;
using RestaurantMVCViewer.Models.DTO;

namespace RestaurantMVCViewer.Models.ViewModels.RestaurantsViewModels
{
    public class IndexRestaurantsVM
    {
        //public IEnumerable<Restaurant> Restaurants { get; set; } = default!; // (!) potential error
        
        // Using DTO
        public IEnumerable<RestaurantDTO> Restaurants { get; set; } = default!; 
        public SelectList DishSL { get; set; } = default!;
        public int DishId { get; set; }
        public string? Search { get; set; }
    }
}
