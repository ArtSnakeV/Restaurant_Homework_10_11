using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant_Homework_10_11.Data;
using Restaurant_Homework_10_11.Data.Entities;
using Restaurant_Homework_10_11.Models.DTO;
using Restaurant_Homework_10_11.Models.ViewModels.RestaurantsViewModels;

namespace Restaurant_Homework_10_11.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly RestaurantsContext _context;

        private readonly ILogger _logger; // Added logger

        private readonly IMapper _mapper; // Added to use AutoMapper

        public RestaurantsController(RestaurantsContext context, ILoggerFactory loggerFactory, IMapper mapper) // Added logger factory
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<RestaurantsController>();
            _mapper = mapper; // Added to use AutoMapper
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

            IQueryable<Dish> dishesIQ = _context.Dishes;
            IEnumerable<DishDTO> dishesDTO = _mapper
                .Map<IEnumerable<DishDTO>>(await dishesIQ.ToListAsync());

            SelectList dishesSL = new SelectList(
            items: dishesDTO,
            dataValueField: "Id",
            dataTextField: "DishName",
            selectedValue: dishId);

            IndexRestaurantsVM vM = new IndexRestaurantsVM
            {
                Restaurants = _mapper.Map<IEnumerable<RestaurantDTO>>(await restaurants.ToListAsync()),
                DishSL = dishesSL,
                DishId = dishId,
                Search = search,
            };
            return View(vM);


            // While using DTO, still without AutoMapper
            //IQueryable<Restaurant> restaurants = _context.Restaurants
            //    .Include(c => c.SignatureDish)
            //    //.Include(c => c.Dish)
            //    .Where(c => c.IsDeleted == false);
            //if (dishId > 0)
            //{
            //    restaurants = restaurants.Where(c => c.DishId == dishId);
            //}
            //if (
            //search is not null)
            //{
            //    restaurants = restaurants.Where(c => c.Name.Contains(search));
            //}
            //IQueryable<Dish> dishes = _context.Dishes;
            //SelectList dishesSL = new SelectList(
            //items: await dishes.ToListAsync(),
            //dataValueField: "Id",
            //dataTextField: "DishName",
            //selectedValue: dishId);

            //IEnumerable<RestaurantDTO> restaurantDTOs = restaurants.ToList().Select(c =>
            //{
            //    return new RestaurantDTO
            //    {
            //        Id = c.Id,
            //        Name = c.Name,
            //        RestaurantDescription = c.RestaurantDescription,
            //        Star = c.Star, // To avoid error here, Michelin star values were commented as well in the RestaurantDTO.cs
            //        WorkingTime = c.WorkingTime,
            //        FirstOpeningDate = c.FirstOpeningDate,
            //        Rating = c.Rating,
            //        Image = c.Image,
            //        SignatureDish = new DishDTO
            //        {
            //            Id = c.SignatureDish!.Id,
            //            DishName = c.SignatureDish.DishName,
            //        }
            //    };
            //}).ToList();
            //IndexRestaurantsVM vM = new IndexRestaurantsVM
            //{
            //    Restaurants = restaurantDTOs, //Restaurants = await restaurants.ToListAsync(),
            //    DishSL = dishesSL,
            //    DishId = dishId,
            //    Search = search,
            //};
            //return View(vM);


            // Before using DTO
            //IQueryable<Restaurant> restaurants = _context.Restaurants
            //    .Include(c => c.SignatureDish)
            //    //.Include(c => c.Dish)
            //    .Where(c => c.IsDeleted == false);
            //if (dishId > 0)
            //{
            //    restaurants = restaurants.Where(c => c.DishId == dishId);
            //}
            //if (
            //search is not null)
            //{
            //    restaurants = restaurants.Where(c => c.Name.Contains(search));
            //}
            //IQueryable<Dish> dishes = _context.Dishes;
            //SelectList dishesSL = new SelectList(
            //items: await dishes.ToListAsync(),
            //dataValueField: "Id",
            //dataTextField: "DishName",
            //selectedValue: dishId);
            //IndexRestaurantsVM vM = new IndexRestaurantsVM
            //{
            //    Restaurants = await restaurants.ToListAsync(),
            //    DishSL = dishesSL,
            //    DishId = dishId,
            //    Search = search,
            //};
            //return View(vM);
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }

            Restaurant? restaurant = await _context.Restaurants
                .Include(c => c.SignatureDish)
                .FirstOrDefaultAsync(m => m.Id == id && m.IsDeleted == false);

            if (restaurant == null)
            {
                return NotFound();
            }


            DetailsRestaurantVM vM = new DetailsRestaurantVM
            {
                Restaurant = _mapper.Map<RestaurantDTO>(restaurant) // restaurant
            };
            return View(vM);



            //WithDTO
            //if (id == null || _context.Restaurants == null)
            //{
            //    return NotFound();
            //}

            //Restaurant? restaurant = await _context.Restaurants
            //    .Include(c => c.SignatureDish)
            //    .FirstOrDefaultAsync(m => m.Id == id);

            //if (restaurant == null)
            //{
            //    return NotFound();
            //}

            ////
            //DishDTO dishDTO = new DishDTO
            //{
            //    Id = restaurant.SignatureDish!.Id,
            //    DishName = restaurant.SignatureDish.DishName,
            //    Image = restaurant.SignatureDish.Image,
            //    DishDescription = restaurant.SignatureDish.DishDescription
            //};

            //RestaurantDTO restaurantDTO = new RestaurantDTO
            //{
            //    Id = restaurant.Id,
            //    Name = restaurant.Name,
            //    Star = restaurant.Star,
            //    FirstOpeningDate = restaurant.FirstOpeningDate,
            //    RestaurantDescription = restaurant.RestaurantDescription,
            //    WorkingTime = restaurant.WorkingTime,
            //    Rating = restaurant.Rating,
            //    Image = restaurant.Image,
            //    DishId = restaurant.DishId,
            //    SignatureDish = dishDTO
            //};

            //DetailsRestaurantVM vM = new DetailsRestaurantVM
            //{
            //    Restaurant = restaurantDTO // restaurant
            //};
            //return View(vM);




            //////////////////////////////////////////////////////
            // Before using DTO
            //if (id == null || _context.Restaurants == null)
            //{
            //    return NotFound();
            //}

            //Restaurant? restaurant = await _context.Restaurants
            //    .Include(c => c.SignatureDish)
            //    .FirstOrDefaultAsync(m => m.Id == id);

            //if (restaurant == null)
            //{
            //    return NotFound();
            //}

            //DetailsRestaurantVM vM = new DetailsRestaurantVM
            //{
            //    Restaurant = restaurant
            //};
            //return View(vM);

            // At the very beginning
            /////////////////////////////////////////////////
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var restaurant = await _context.Restaurants
            //    .Include(r => r.SignatureDish)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (restaurant == null)
            //{
            //    return NotFound();
            //}

            //return View(restaurant);
        }

        // GET: Restaurants/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Id");
            //return View

            IQueryable<Dish> dishesIQ = _context.Dishes;

            IEnumerable<DishDTO> dishesDTO = _mapper
                .Map<IEnumerable<DishDTO>>(await dishesIQ.ToListAsync());

            SelectList dishesSL = new SelectList(
                items: dishesDTO,
                dataValueField: "Id",
                dataTextField: "DishName");

            CreateRestaurantVM vM = new CreateRestaurantVM
            {
                DishSL = dishesSL,
            };

            return View(vM);
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRestaurantVM vM)
        {
            if (ModelState.IsValid == false)
            {
                IQueryable<Dish> dishesIQ = _context.Dishes;

                IEnumerable<DishDTO> dishesDTO = _mapper
                    .Map<IEnumerable<DishDTO>>(await dishesIQ.ToListAsync());

                SelectList dishesSL = new SelectList(
                    items: dishesDTO,
                    dataValueField: "Id",
                    dataTextField: "DishName",
                    selectedValue: vM.Restaurant.DishId);

                vM.DishSL = dishesSL;

                foreach (var item in ModelState.Values.SelectMany(e => e.Errors))
                {
                    _logger.LogError(item.ErrorMessage);
                }

                return View(vM);
            }
            byte[]? data = null;
            using (BinaryReader br = new BinaryReader(vM.Image.OpenReadStream()))
            {
                data = br.ReadBytes((int)vM.Image.Length);
                vM.Restaurant.Image = data;
            }

            Restaurant creatingRestaurant = _mapper.Map<Restaurant>(vM.Restaurant);

            _context.Add(creatingRestaurant);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //Before using AutoMapper
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(
        //    [Bind(
        //        nameof(Restaurant.Name),
        //        nameof(Restaurant.RestaurantDescription),
        //        nameof(Restaurant.FirstOpeningDate),
        //        nameof(Restaurant.Star),
        //        nameof(Restaurant.WorkingTime),
        //        nameof(Restaurant.Rating),
        //        nameof(Restaurant.DishId)
        //        //nameof(Restaurant.IsDeleted) // Protection from overpost
        //    //)] Restaurant restaurant, // Changed while using DTO
        //    )] RestaurantDTO restaurant,
        //    IFormFile image)
        //{
        //    // Own writing, lot listed in example
        //    CreateRestaurantVM vM = new CreateRestaurantVM
        //    {
        //        Restaurant = restaurant
        //    };
        //    //To be checked
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(restaurant);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Id", restaurant.DishId);

        //    return View(vM);
        //}



        //public async Task<IActionResult> Create([Bind("Id,Name,Star,FirstOpeningDate,RestaurantDescription,WorkingTime,Rating,Image,IsDeleted,DishId")] Restaurant restaurant) // With is deleted
        //public async Task<IActionResult> Create([Bind("Id,Name,Star,FirstOpeningDate,RestaurantDescription,WorkingTime,Rating,Image,DishId")] Restaurant restaurant)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(restaurant);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Id", restaurant.DishId);
        //    return View(restaurant);
        //}

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }

            Restaurant? restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null ||  restaurant.IsDeleted == true)
            {
                return NotFound();
            }

            IQueryable<Dish> dishesIQ = _context.Dishes;

            IEnumerable<DishDTO> dishesDTO = _mapper
                .Map<IEnumerable<DishDTO>>(await dishesIQ.ToListAsync());

            SelectList dishesSl = new SelectList(
                dishesDTO,
                "Id",
                "DishName",
                restaurant.DishId);

            EditRestaurantVM vM = new EditRestaurantVM
            {
                Restaurant = _mapper.Map<RestaurantDTO>(restaurant),
                DishSL = dishesSl,
            };

            return View(vM);


            // Before DTO
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var restaurant = await _context.Restaurants.FindAsync(id);
            //if (restaurant == null)
            //{
            //    return NotFound();
            //}
            //ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Id", restaurant.DishId);
            //return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditRestaurantVM vM)
        {
            if (id != vM.Restaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid == false)
            {
                IQueryable<Dish> dishesIQ = _context.Dishes;

                IEnumerable<DishDTO> dishesDTO = _mapper
                    .Map<IEnumerable<DishDTO>>(await dishesIQ.ToListAsync());

                SelectList dishesSL = new SelectList(
                    dishesDTO,
                    "Id",
                    "DishName",
                    vM.Restaurant.DishId);

                vM.DishSL = dishesSL;

                return View(vM);
            }

            if(vM.Image is not null)
            {
                byte[]? data = null;
                using (BinaryReader br = new BinaryReader(vM.Image.OpenReadStream()))
                {
                    data = br.ReadBytes((int)vM.Image.Length);
                    vM.Restaurant.Image = data;
                }
            }

            try
            {
                Restaurant restaurantToEdit = _mapper.Map<Restaurant>(vM.Restaurant);

                _context.Update(restaurantToEdit);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(vM.Restaurant.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));


            // Before modifying
            //if (id != restaurant.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(restaurant);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!RestaurantExists(restaurant.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["DishId"] = new SelectList(_context.Dishes, "Id", "Id", restaurant.DishId);
            //return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }

            Restaurant? restaurant = await _context.Restaurants
                .Include(r => r.SignatureDish)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (restaurant == null)
            {
                return NotFound();
            }

            DeleteRestaurantVM vM = new DeleteRestaurantVM
            {
                Restaurant = _mapper.Map<RestaurantDTO>(restaurant)
            };

            return View(vM);


            //Before changes
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var restaurant = await _context.Restaurants
            //    .Include(r => r.SignatureDish)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (restaurant == null)
            //{
            //    return NotFound();
            //}

            //return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Restaurants == null)
            {
                return Problem("Entity set `RestaurantContext.Restaurants' is null.");
            }

            Restaurant? restaurant = await _context.Restaurants.FindAsync(id);
            if(restaurant != null)
            {
                restaurant.IsDeleted = true;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            // Before changes
            //var restaurant = await _context.Restaurants.FindAsync(id);
            //if (restaurant != null)
            //{
            //    _context.Restaurants.Remove(restaurant);
            //}

            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }
    }
}
