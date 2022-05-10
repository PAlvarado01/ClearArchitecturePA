﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearArchitecture.UseCases.CreateOrder
{
    public class CreateOrderValidator: AbstractValidator<CreateOrderInputPort>
    {
        public CreateOrderValidator()
        {
            RuleFor(c => c.RequestData.CustomerId).NotEmpty().WithMessage("Debe proporcionar el identificador del cliente.");
            RuleFor(c => c.RequestData.ShipAddress).NotEmpty().WithMessage("Debe proporcionar la dirección de envio.");
            RuleFor(c => c.RequestData.ShipCity).NotEmpty().MinimumLength(3).WithMessage("Debe proporcionar al menos 3 caracteres del nombre de la Ciudad.");
            RuleFor(c => c.RequestData.ShipCountry).NotEmpty().MinimumLength(3).WithMessage("Debe proporcionar al menos 3 caracteres del nombre del País.");
            RuleFor(c => c.RequestData.OrderDetails).Must(d => d != null && d.Any()).WithMessage("Deben especificarse los productos de la orden.");
        }
    }
}
