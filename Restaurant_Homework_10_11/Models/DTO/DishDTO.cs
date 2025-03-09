using Restaurant_Homework_10_11.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Homework_10_11.Models.DTO
{
    public class DishDTO
    {
        public int Id { get; set; }
        [Display(Name = "Dish")]
        [MinLength(3)]
        public string DishName { get; set; } = default!; // input
        public string? DishDescription { get; set; } // textarea
        public byte[]? Image { get; set; }

        public ICollection<RestaurantDTO>? Restaurants { get; set; } = default;
    }
}