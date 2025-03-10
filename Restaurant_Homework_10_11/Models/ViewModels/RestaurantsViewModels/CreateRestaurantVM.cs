using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant_Homework_10_11.Data.Entities;
using Restaurant_Homework_10_11.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Homework_10_11.Models.ViewModels.RestaurantsViewModels
{
    public class CreateRestaurantVM
    {
        //public Restaurant Restaurant { get; set; } = default!; // (!) potential error
        public RestaurantDTO Restaurant { get; set; } = default!;
        public SelectList DishSL { get; set; } = default!;
        //public int DishId { get; set; }

        [Required]
        public IFormFile Image { get; set; } = default!;
    }
}


