using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Homework_10_11.Data.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        [Display(Name = "Dish")]
        [MinLength(3)]
        public string DishName { get; set; } = default!; // input
        public string? DishDescription { get; set; } // textarea
        public byte[]? Image { get; set; }

        public ICollection<Restaurant>? Restaurants { get; set; } = default;
    }
}
