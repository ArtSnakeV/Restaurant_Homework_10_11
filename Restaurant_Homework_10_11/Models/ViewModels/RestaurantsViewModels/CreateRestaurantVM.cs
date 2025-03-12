using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantMVCViewer.Data.Entities;
using RestaurantMVCViewer.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace RestaurantMVCViewer.Models.ViewModels.RestaurantsViewModels
{
    public class CreateRestaurantVM
    {
        //public Restaurant Restaurant { get; set; } = default!; // (!) potential error
        public RestaurantDTO Restaurant { get; set; } = default!;
        public SelectList? DishSL { get; set; } = default!;
        //public int DishId { get; set; }

        [Required]
        public IFormFile Image { get; set; } = default!;
    }
}


