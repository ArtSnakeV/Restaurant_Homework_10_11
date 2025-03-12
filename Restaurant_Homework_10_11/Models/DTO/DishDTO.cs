using RestaurantMVCViewer.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace RestaurantMVCViewer.Models.DTO
{
    public class DishDTO
    {
        public int Id { get; set; }
        [Display(Name = "Signature dish")]
        [MinLength(3)]
        public string DishName { get; set; } = default!; // input
        public string? DishDescription { get; set; } // textarea
        public byte[]? Image { get; set; }

        public ICollection<RestaurantDTO>? Restaurants { get; set; } = default;
    }
}