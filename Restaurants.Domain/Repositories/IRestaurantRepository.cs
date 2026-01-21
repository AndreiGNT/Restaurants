using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IRestaurantRepository
{
    Task<Restaurant?> GetRestaurantAsync(int id);
}
