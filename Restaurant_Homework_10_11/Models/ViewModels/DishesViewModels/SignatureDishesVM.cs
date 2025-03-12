using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantMVCViewer.Models.DTO;

namespace RestaurantMVCViewer.Models.ViewModels.DishesViewModels
{
    public class SignatureDishesVM
    {
        public IEnumerable<DishDTO> Dishes { get; set; } = default!;
    }
}
