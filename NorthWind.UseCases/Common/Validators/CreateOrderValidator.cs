using FluentValidation;
using NorthWind.UseCasesDTOs.CreateOrder;
using System.Linq;

namespace NorthWind.UseCases.Common.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderParams>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.CustomerId)
                .NotEmpty().WithMessage("You must provide the client identifier");

            RuleFor(c => c.ShipAddress)
                .NotEmpty().WithMessage("You must provide the shipping address");

            RuleFor(c => c.ShipCity)
                .NotEmpty()
                .MinimumLength(3).WithMessage("You must provide at least 3 characters of the city name");

            RuleFor(c => c.ShipCountry)
                .NotEmpty()
                .MinimumLength(3).WithMessage("You must provide at least 3 characters of the country name");

            RuleFor(c => c.OrderDetails)
                .Must(d => d != null && d.Any()).WithMessage("The products of the order must be specified");
        }
    }
}
