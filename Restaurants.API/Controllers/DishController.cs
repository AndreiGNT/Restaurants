using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants/{restaurntId}/dishes")]
public class DishController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute]int restaurntId, CreateDishCommand command)
    {
        command.RestaurantId = restaurntId;

        await mediator.Send(command);
        return Created();
    }
}
