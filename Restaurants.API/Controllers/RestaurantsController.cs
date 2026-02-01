using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/Restaurants")]
public class RestaurantsController( IMediator mediator ) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var retaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(retaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        var retaurant = await mediator.Send(new GetRestaurantByIdQuery(id));

        if (retaurant == null)
        {
            return NotFound();
        }

        return Ok(retaurant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
    {
        int id = await mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}
