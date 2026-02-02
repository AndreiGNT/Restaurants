using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> validCategories = ["Fast Food", "Fine Dining", "Average Food"];

    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 50)
            .WithMessage("The name is required with a length between of 3 to 50.");

        RuleFor(dto => dto.Description)
            .NotEmpty()
            .WithMessage("Description is required.");

        RuleFor(dto => dto.Category)
            .Must(validCategories.Contains)
            .WithMessage("A valid category is required.");

        RuleFor(dto => dto.ContactEmail)
            .EmailAddress()
            .WithMessage("A valid email is required.");

        RuleFor(dto => dto.PostalCode)
            .Matches(@"^[A-Z]{2}-\d{4}$")
            .WithMessage("Please provide a valid postal code (AB-0000).");

        RuleFor(dto => dto.ContactNumber)
            .Matches(@"^\+\d{11}$")
            .WithMessage("Please provide a valid phone number +373...");
    }
}
