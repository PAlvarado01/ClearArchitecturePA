using ClearArchitecture.Entities.CAEntities;
using ClearArchitecture.Entities.Interfaces;
using ClearArchitecture.Entities.Specifications;
using ClearArchitecture.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearArchitecture.Repositories.EFCore.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly ClearArchitectureContext Context;
        public OrderRepository(ClearArchitectureContext context) =>
            Context = context;
        public void Create(Order order)
        {
            Context.Add(order);
        }

        public IEnumerable<Order> GetOrdersBySpecification(Specification<Order> specification)
        {
            var ExpressionDelegate = specification.Expression.Compile();
            return Context.Orders.Where(ExpressionDelegate);
        }
    }
}
