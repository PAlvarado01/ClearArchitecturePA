using ClearArchitecture.UseCasesDTOs.CreateOrder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearArchitecture.UseCases.CreateOrder
{
    public class CreateOrderInputPort:CreateOrderParams,IRequest<int>
    {

    }
}
