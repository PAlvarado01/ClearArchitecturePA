using FluentValidation;
using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.UseCases.Common.Validators;
using NorthWind.UseCasesDTOs.CreateOrder;
using NorthWind.UseCasesDTOs.GetAllOrders;
using NorthWind.UseCasesPorts.CreateOrder;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInteractor : ICreateOrderInputPort
    {
        readonly IOrderRepository orderRepository;
        readonly IOrderDetailRepository orderDetailRepository;
        readonly IUnitOfWork unitOfWork;
        readonly ICreateOrderOutputPort outputPort;
        readonly IEnumerable<IValidator<CreateOrderParams>> validators;

        public CreateOrderInteractor(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork, ICreateOrderOutputPort outputPort, IEnumerable<IValidator<CreateOrderParams>> validators)
        {
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.unitOfWork = unitOfWork;
            this.outputPort = outputPort;
            this.validators = validators;
        }

        public async Task Handle(CreateOrderParams order)
        {
            await Validator<CreateOrderParams>.Validate(order, validators);
            var Order = new Order
            {
                CustomerId = order.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipCountry = order.ShipCountry,
                ShipPostalCode = order.ShipPostalCode,
                shippingType = Entities.Enums.ShippingType.Road,
                DiscountType = Entities.Enums.DiscountType.Percentage,
                Discount = 10
            };

            orderRepository.Create(Order);

            foreach (var item in order.OrderDetails)
            {
                orderDetailRepository.Create(new OrderDetail
                {
                    Order = Order,
                    ProductId = item.ProductId,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity
                });
            }

            try
            {
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error creating order", ex.Message);
            }

            await outputPort.Handle(Order.Id);
        }
    }
}
