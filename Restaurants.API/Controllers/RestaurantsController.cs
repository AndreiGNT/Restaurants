using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/Restaurants")]
public class RestaurantsController(IRestaurantsService restaurantsService
                                   ) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var retaurants = await restaurantsService.GetAllRestaurants();
        return Ok(retaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRestaurant([FromRoute]int id)
    {
        var retaurant = await restaurantsService.GetRestaurant(id);

        if (retaurant == null)
        {
            return NotFound();
        }

        return Ok(retaurant);
    }
}
