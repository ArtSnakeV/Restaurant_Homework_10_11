using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using RestaurantMVCViewer.AutoMapperProfiles;
using RestaurantMVCViewer.Data;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);


//Added to use AutoMapper
builder.Services.AddAutoMapper(
    typeof(RestaurantProfile),
    typeof(DishProfile)
    );

builder.Services.AddDbContext<RestaurantsContext>(options =>
    options.UseSqlServer(
        builder.Configuration
        .GetConnectionString("RestaurantsContext") ??
            throw new InvalidOperationException(
                "Connection string `RestaurantsContext` not found.")));



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider serviceProvider = scope.ServiceProvider;

    await SeedData.Initialize(
        serviceProvider,
        app.Environment,
        app.Configuration);
}


    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. We may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
