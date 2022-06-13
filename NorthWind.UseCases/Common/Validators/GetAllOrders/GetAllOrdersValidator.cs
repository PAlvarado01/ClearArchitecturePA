using NorthWind.UseCasesDTOs.GetAllOrders;
using FluentValidation;

namespace NorthWind.UseCases.Common.Validators.GetAllOrders
{
    public class GetAllOrdersValidator : AbstractValidator<GetAllOrdersParams>
    {
        public GetAllOrdersValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty().WithMessage("You must provide the client identifier");
        }
    }
}
