using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/Restaurants")]
public class RestaurantsController(IRestaurantsService restaurantsService, 
                                    IRestaurantService restaurantService
                                   ) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var retaurants = await restaurantsService.GetAllRestaurants();
        return Ok(retaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRestaurant(int id)
    {
        var retaurant = await restaurantService.GetRestaurant(id);

        if (retaurant == null)
        {
            return NotFound();
        }

        return Ok(retaurant);

    }
}
