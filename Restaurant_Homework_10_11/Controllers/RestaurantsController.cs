using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant_Homework_10_11.Data;
using Restaurant_Homework_10_11.Data.Entities;
using Restaurant_Homework_10_11.Models.ViewModels.RestaurantsViewModels;

namespace Restaurant_Homework_10_11.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly RestaurantsContext _context;

        private readonly ILogger _logger; // Added logger

        public RestaurantsController(RestaurantsContext context, ILoggerFactory loggerFactory) // Added logger factory
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<RestaurantsController>();
        }

        
        // GET: Restaurants
        //public async Task<IActionResult> Index()
        //{
        //    var restaurantsContext = _context.Restaurants.Include(r => r.SignatureDish);
        //    return View(await restaurantsContext.ToListAsync());
        //}

        public async Task<IActionResult> Index(int dishId, string? search)
        {
            IQueryable<Restaurant> restaurants = _context.Restaurants
                .Include(c => c.SignatureDish)
                //.Include(c => c.Dish)
                .Where(c => c.IsDeleted == false);
            if (dishId > 0)
            {
                restaurants = restaurants.Where(c => c.DishId == dishId);
            }
            if (
            search is not null)
            {
                restaurants = restaurants.Where(c => c.Name.Contains(search));
            }
            IQueryable<Dish> dishes = _context.Dishes;
            SelectList dishesSL = new SelectList(
            items: await dishes.ToListAsync(),
            dataValueField: "Id",
            dataTextField: "DishName",
            selectedValue: dishId);
            IndexRestaurantsVM vM = new IndexRestaurantsVM
            {
                Restaurants = await restaurants.ToListAsync(),
                DishSL = dishesSL,
                DishId = dishId,
                Search = search,
            };
            return View(vM);
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .Include(r => r.SignatureDish)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Id");
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Star,FirstOpeningDate,RestaurantDescription,WorkingTime,Rating,Image,IsDeleted,DishId")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Id", restaurant.DishId);
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Id", restaurant.DishId);
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Star,FirstOpeningDate,RestaurantDescription,WorkingTime,Rating,Image,IsDeleted,DishId")] Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Id", restaurant.DishId);
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .Include(r => r.SignatureDish)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }
    }
}
