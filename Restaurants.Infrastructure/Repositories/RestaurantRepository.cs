using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantRepository(RestaurantsDbContext dbContext) : IRestaurantRepository
{
    public async Task<Restaurant?> GetRestaurantAsync(int id)
    {
        var restaurant = await dbContext.Restaurants.FindAsync(id);

        return restaurant;
    }
}
