using FluentValidation;
using NorthWind.UseCasesDTOs.GetAllOrders;

namespace NorthWind.UseCases.GetAllOrders
{
    public class GetAllOrdersValidator : AbstractValidator<GetAllOrdersParams>
    {
        public GetAllOrdersValidator()
        {
            RuleFor(c => c.CustomerId)
                .NotEmpty().WithMessage("You must provide the client identifier");
        }
    }
}
