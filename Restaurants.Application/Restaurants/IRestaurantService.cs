using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants;

public interface IRestaurantService
{
    Task<Restaurant?> GetRestaurant(int id);
}