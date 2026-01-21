using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantService(IRestaurantRepository restaurantRepository,
    ILogger<RestaurantsService> logger) : IRestaurantService
{
    public async Task<Restaurant?> GetRestaurant(int id)
    {
        logger.LogInformation("Getting one Restaurant.");
        var restaurant = await restaurantRepository.GetRestaurantAsync(id);
        return restaurant;
    }
}
