using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RestaurantMVCViewer.Data.Entities;
using RestaurantMVCViewer.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace RestaurantMVCViewer.Data
{
    public class SeedData // Class to initialize our database with starting data
    {
        public static async Task Initialize(
            IServiceProvider serviceProvider,
            IWebHostEnvironment webHostEnvironment,
            IConfiguration configuration
            )
        {
            DbContextOptions<RestaurantsContext> options =
                serviceProvider.GetRequiredService<DbContextOptions<RestaurantsContext>>();

            using (RestaurantsContext context = new RestaurantsContext(options))
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                if (context.Restaurants.Any())
                {
                    return;
                }

                // Images for restaurants
                byte[] restaurantImage1 = File.ReadAllBytes(
                    $"{webHostEnvironment.WebRootPath}\\images\\Restaurants\\restaurant1.jpeg");

                byte[] restaurantImage2 = File.ReadAllBytes(
                    $"{webHostEnvironment.WebRootPath}\\images\\Restaurants\\restaurant2.jpeg");

                byte[] restaurantImage3 = File.ReadAllBytes(
                    $"{webHostEnvironment.WebRootPath}\\images\\Restaurants\\restaurant3.jpeg");

                byte[] restaurantImage4 = File.ReadAllBytes(
                    $"{webHostEnvironment.WebRootPath}\\images\\Restaurants\\restaurant4.jpeg");

                byte[] restaurantImage5 = File.ReadAllBytes(
                    $"{webHostEnvironment.WebRootPath}\\images\\Restaurants\\restaurant5.jpeg");


                // Dishes
                Dish pudding = new Dish
                {
                    DishName = "Yorkshire Pudding",
                    DishDescription = "This cold country is the home of Roast Beef with Yorkshire Pudding – something to warm you up when it’s snowing outside. For another option, don’t miss the chance to try a Cornish Pasty",
                    Image = File.ReadAllBytes(
                    $"{webHostEnvironment.WebRootPath}\\images\\Dishes\\pudding.jpg")
                };

                Dish macarons = new Dish
                {
                    DishName = "Macarons",
                    DishDescription = "So light and sweet, with every flavour you can imagine (and some you couldn’t), Macarons are a favourite around the world",
                    Image = File.ReadAllBytes(
                    $"{webHostEnvironment.WebRootPath}\\images\\Dishes\\macarons.jpg")
                };

                Dish strudel = new Dish
                {
                    DishName = "Apfelstrudel",
                    DishDescription = "The pastry is filled with cooked apple, sugar, cinnamon, raisings and bread crumbs. Best served warm with vanilla ice cream.",
                    Image = File.ReadAllBytes(
                    $"{webHostEnvironment.WebRootPath}\\images\\Dishes\\strudel.jpg")
                };


                Dish spaghetti = new Dish
                {
                    DishName = "Spaghetti with ham, ceps and black truffle",
                    DishDescription = "Starts with a soffritto mix of finely chopped onion, celery and carrot (plus garlic) and is flavoured further by diced tomatoes, oregano and nutmeg.",
                    Image = File.ReadAllBytes(
                   $"{webHostEnvironment.WebRootPath}\\images\\Dishes\\spaghetti.jpg")
                };

                Dish paella = new Dish
                {
                    DishName = "Spanish Paella",
                    DishDescription = "This famous saffron infused rice dish is a traditional Spanish recipe that comes fully loaded with seafood or anything your heart desires!",
                    Image = File.ReadAllBytes(
                   $"{webHostEnvironment.WebRootPath}\\images\\Dishes\\paella.jpg")
                };
                               

                // Restaurants
                Restaurant rest1 = new Restaurant
                {
                    Name = "Night is quiet",
                    MichelinStar = MichelinStar.Three.ToString(),
                    //Star = MichelinStar.Three,
                    FirstOpeningDate = DateTime.Parse("10 - 11 - 1900"),
                    RestaurantDescription = "Nestled in a charming corner of the city, this culinary gem invites you to indulge in a fusion of traditional and contemporary flavors. With warm wooden accents and soft lighting, the ambiance exudes a cozy yet sophisticated vibe. The menu showcases an array of seasonal dishes, each artfully presented, highlighting the freshest local ingredients. Signature offerings include a delicate seafood risotto infused with saffron and a decadent chocolate torte that melts in your mouth. Pair your meal with a curated selection of organic wines, and let the knowledgeable staff guide you through an unforgettable gastronomic journey.",
                    WorkingTime = "10 - 23",
                    Rating = 10.0f,
                    Image = restaurantImage1,
                    IsDeleted = false,
                    SignatureDish = pudding
                };

                Restaurant rest2 = new Restaurant
                {
                    Name = "Soft clouds",
                    MichelinStar = MichelinStar.Two.ToString(),
                    //Star = MichelinStar.Two,
                    FirstOpeningDate = DateTime.Parse("12 - 08 - 1998"),
                    RestaurantDescription = "Perched atop a bustling rooftop, this eatery offers breathtaking panoramic views of the skyline while serving an eclectic menu inspired by global street food. The vibrant decor, adorned with colorful murals and strings of twinkling lights, sets the stage for a lively dining experience. Guests can savor tantalizing small plates, from spicy Korean tacos to zesty Mediterranean mezze, perfect for sharing. The cocktail menu is equally adventurous, featuring inventive concoctions that blend unexpected flavors, making each sip a delightful surprise. Whether you're watching the sunset or enjoying a night under the stars, this restaurant promises a feast for all the senses.",
                    WorkingTime = "10 - 24",
                    Rating = 9.7f,
                    Image = restaurantImage2,
                    IsDeleted = false,
                    SignatureDish = macarons
                };

                Restaurant rest3 = new Restaurant
                {
                    Name = "Connecting people",
                    MichelinStar = MichelinStar.One.ToString(),
                    //Star = MichelinStar.One,
                    FirstOpeningDate = DateTime.Parse("03 - 12 - 2008"),
                    RestaurantDescription = "Step into a world of elegance at this upscale bistro, where classic French cuisine meets modern culinary techniques. The sophisticated interior, with its plush seating and gilded accents, creates an atmosphere of refined luxury. Diners can expect an exquisite menu that includes buttery escargots, perfectly seared duck breast, and a selection of artisanal cheeses that would delight any connoisseur. The attentive staff, dressed in crisp uniforms, offers impeccable service while guiding you through a carefully curated wine list. Ideal for a romantic evening or a special celebration, this restaurant is where unforgettable memories are made.",
                    WorkingTime = "14 - 23:30",
                    Rating = 9.98f,
                    Image = restaurantImage3,
                    IsDeleted = false,
                    SignatureDish = strudel
                };

                Restaurant rest4 = new Restaurant
                {
                    Name = "Touchless",
                    MichelinStar = MichelinStar.One.ToString(),
                    //Star = MichelinStar.One,
                    FirstOpeningDate = DateTime.Parse("11 - 08 - 2003"),
                    RestaurantDescription = "Hidden down a narrow alley, this rustic eatery has a warm, inviting charm reminiscent of a countryside cottage. The walls are adorned with vintage photographs and handmade decorations that tell a story of tradition and heritage. The menu is a celebration of comfort food, featuring hearty dishes such as homemade pasta tossed in rich, savory sauces and slow-cooked stews that warm the soul. Each meal is crafted with love and care, using recipes passed down through generations. Don’t miss the freshly baked bread served with whipped herb butter, the perfect accompaniment to your meal. This restaurant is a testament to the power of home-cooked flavors.",
                    WorkingTime = "08 - 23:45",
                    Rating = 9.81f,
                    Image = restaurantImage4,
                    IsDeleted = false,
                    SignatureDish = spaghetti
                };

                Restaurant rest5 = new Restaurant
                {
                    Name = "Raising Star",
                    MichelinStar = MichelinStar.Zero.ToString(),
                    //Star = MichelinStar.Zero,
                    FirstOpeningDate = DateTime.Parse("10 - 01 - 2021"),
                    RestaurantDescription = "This lively, modern diner reimagines the classic American experience with a playful twist. Bright colors and retro decor create a fun atmosphere, inviting guests of all ages to enjoy a memorable meal. The menu is filled with inventive takes on beloved favorites, from gourmet burgers topped with artisanal cheeses to crispy fried chicken served with a side of spicy honey. For those with a sweet tooth, the dessert menu features over-the-top milkshakes and whimsical pastries that are as delightful to look at as they are to taste. With a focus on locally sourced ingredients and a friendly, energetic vibe, this restaurant is a celebration of all things delicious and nostalgic.",
                    WorkingTime = "10 - 23",
                    Rating = 9.93f,
                    Image = restaurantImage5,
                    IsDeleted = false,
                    SignatureDish = paella
                };

                await context.AddRangeAsync(
                    rest1,
                    rest2,
                    rest3,
                    rest4,
                    rest5);

                await context.SaveChangesAsync();                

            }
        }

    }
}
