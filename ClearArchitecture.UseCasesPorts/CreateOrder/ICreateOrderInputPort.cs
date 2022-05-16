using ClearArchitecture.UseCasesDTOs.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearArchitecture.UseCasesPorts.CreateOrder
{
    public interface ICreateOrderInputPort
    {
        Task Handle(CreateOrderParams order);
    }
}
