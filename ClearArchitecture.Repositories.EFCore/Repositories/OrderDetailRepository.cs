using ClearArchitecture.Entities.CAEntities;
using ClearArchitecture.Entities.Interfaces;
using ClearArchitecture.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearArchitecture.Repositories.EFCore.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {   
        readonly ClearArchitectureContext Context;
        public OrderDetailRepository(ClearArchitectureContext context) =>
            Context = context;
        public void Create(OrderDetail orderDetail)
        {
            Context.Add(orderDetail);
        }
    }
}
