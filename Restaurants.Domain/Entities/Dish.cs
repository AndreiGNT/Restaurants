namespace Restaurants.Domain.Entities;

public class Dish
{
    public int Id { get; set; }
    string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
}
