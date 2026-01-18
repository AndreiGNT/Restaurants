using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeder;

internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();

            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = [
            new()
            {
                Name = "KFC",
                Description = "KFC is a fast food retaurant with the best chicken wing.",
                Category = "Fast Food",
                HasDelivery = true,

                ContactEmail = "contactkfc@gmail.com",
                ContactNumber = "+373 023-456-789",

                Address = new() {
                    City = "Chisinau",
                    Street = "Bulevardul Stefan Cel Mare 17/2",
                    PostalCode = "MD-5320"
                },

                Dishes =
                [
                    new() {
                        Name = "20 Hot Chicken Wings",
                        Description = "The best test ever of doing eating go no lisa wings good no regret etc..",
                        Price = 18.90M
                    },

                    new() {
                        Name = "6 Hot Chicken Wings",
                        Description = "The best test ever of 6 eating go no lisa wings good no regret",
                        Price = 12.90M
                    }
                ]
            },

            new()
            {
                Name = "McDonalds",
                Description = "McDonalds is a fast food retaurant burgers the best burger wing.",
                Category = "Fast Food",
                HasDelivery = true,

                ContactEmail = "contactmc@gmail.com",
                ContactNumber = "+373 023-456-789",

                Address = new() {
                    City = "Chisinau",
                    Street = "Bulevardul Stefan Cel Mare 17/3",
                    PostalCode = "MD-5320"
                },

                Dishes =
                [
                    new() {
                        Name = "Big Burger",
                        Description = "The best test Big Burger ever of doing eating Big Burger go no lisa.",
                        Price = 18.90M
                    },

                    new() {
                        Name = "Burger kids",
                        Description = "The best Burger kids ever of 6 eating go no lisa Burger kids good no regret",
                        Price = 12.90M
                    }
                ]
            }

        ];

        return restaurants;
    }
}
