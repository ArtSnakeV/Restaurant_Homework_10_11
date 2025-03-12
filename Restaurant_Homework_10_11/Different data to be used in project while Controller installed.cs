using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantMVCViewer.Data.Entities;
using RestaurantMVCViewer.Models.ViewModels.RestaurantsViewModels;

namespace RestaurantMVCViewer
{
    public class Different_data_to_be_used_in_project_while_Controller_installed
    {

    }
}




////////////////////////////////////////
/// Inside RestaurantsController.Index.cs   page 31
//public async Task<IActionResult> Index(int dishId, string? search)
//{
//    IQueryable<Restaurant> restaurants = _context.Restaurants
//        .Include(r => r.Dish)
//        .Where(r => r.IsDeleted == false);

//    if (dishId > 0)
//    {
//        restaurants = restaurants.Where(r => r.DishId == dishId);
//    }
//    if(search is not null)
//    {
//        dishes = dishes.Where(r => r.Name.Contains(search));
//    }
//    IQueryable<Dish> dishes = _context.Dishes;

//    SelectList dishesSL = new SelectList(
//        items: await dishes.ToListAsync(),
//        dataValueField: "Id",
//        dataTextField: "Name",
//        selectedValue: dishId);

//    IndexRestaurantsVM vM = new IndexRestaurantsVM
//    {
//        Restaurants = await restaurants.ToListAsync(),
//        RestaurantSL = restaurantSL,
//        RestaurantId = restaurantId,
//        Search = search,
//    };
//    return View(vM);
//}





