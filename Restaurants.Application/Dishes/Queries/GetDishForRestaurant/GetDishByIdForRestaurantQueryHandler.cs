using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishForRestaurant;

public class GetDishByIdForRestaurantQueryHandler(
        IRestaurantsRepository restaurantsRepository,
        ILogger<GetRestaurantByIdQueryHandler> logger,
        IMapper mapper
                                            ) : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting Dish with Id: {@DishId}, for Restaurant with Id: {@RestaurantId}", request.DishId, request.RestaurantId);

        var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);

        if (restaurant == null)
        {
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
        }

        var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);

        if (dish == null)
        {
            throw new NotFoundException(nameof(Dish), request.DishId.ToString());
        }

        var dishDto = mapper.Map<DishDto>(dish);

        return dishDto;
    }
}
