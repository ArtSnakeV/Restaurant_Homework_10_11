using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestaurantMVCViewer.Data.Entities;
using System.Collections.Generic;

namespace RestaurantMVCViewer.Data
{
    public class RestaurantsContext : DbContext
    {
        public RestaurantsContext(DbContextOptions<RestaurantsContext> options) :
            base(options)
        {
            //Database.EnsureCreated(); // To be commented while using migrations
        }

        // First way
        public DbSet<Restaurant> Restaurants { get; set; } = default!;

        public DbSet<Dish> Dishes { get; set; } = default!;

        // Second way
        //public DbSet<Restaurant> Restaurants => Set<Restaurant>();
        //public DbSet<Dish> Dishes => Set<Dish>();

    }
}

//21