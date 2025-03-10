
using System.ComponentModel.DataAnnotations;

namespace Restaurant_Homework_10_11.Data.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Restaurant name")]
        public string Name { get; set; } = default!;

        public string MichelinStar { get; set; } = default!;
        //public MichelinStar Star { get; set; } // radio buttons

        public DateTime FirstOpeningDate { get; set; }

        public string? RestaurantDescription { get; set; } // textarea

        public string WorkingTime { get; set; } = default!;

        public float? Rating { get; set; }

        public byte[]? Image { get; set; }

        public bool IsDeleted { get; set; } // For `soft` deleting of item

        // The restaurant signature dish
        public int DishId { get; set; }
        public Dish SignatureDish { get; set; } = default!;
    }

    // Commented strings were here before, but after We move them to the MichelinStar.cs
    //public enum MichelinStar
    //{
    //    Zero, One, Two, Three
    //}
}