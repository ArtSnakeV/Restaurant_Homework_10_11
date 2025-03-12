using System.ComponentModel.DataAnnotations;

namespace RestaurantMVCViewer.Models.DTO
{
    public class RestaurantDTO
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Restaurant name")]
        public string Name { get; set; } = default!;

        public MichelinStar MichelinStar { get; set; } // radio buttons

        public DateTime FirstOpeningDate { get; set; }

        public string? RestaurantDescription { get; set; } // textarea

        public string WorkingTime { get; set; } = default!;

        public float? Rating { get; set; }

        public byte[]? Image { get; set; }

        //public bool IsDeleted { get; set; } // For `soft` deleting of item

        // The restaurant signature dish
        public int DishId { get; set; }
        public DishDTO? SignatureDish { get; set; } = default!;
    }
    //public enum MichelinStar
    //{
    //    Zero, One, Two, Three
    //}
}
