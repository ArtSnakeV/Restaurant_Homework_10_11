using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Restaurant_Homework_10_11.Data.Entities;
using Restaurant_Homework_10_11.Models.ViewModels.RestaurantsViewModels;

namespace Restaurant_Homework_10_11
{
    public class Different_data_to_be_used_in_project_while_Controller_installed
    {

    }
}

//// In class controller
//// RestaurantsController 

//private readonly ILogger _logger;

//// in contstructor
//ILoggerFactory loggerFactory
//_logger = loggerFactory.CreateLogger<CatsController>();

////////////////////////////////////
///// Inside IndexRestaurantsVM.cs
//using Restaurant_Homework_10_11.Data.Entities;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace....
//{
//    public class IndexCatsVM
//    {
//        public IEnumerable<Restaurant> Restaurants { get; set; } = default!; // (!) potential error
//        public SelectList DishSL { get; set; } = default!;
//        public int DishId { get; set; }
//        public string? Search { get; set; }
//    }
//}

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





