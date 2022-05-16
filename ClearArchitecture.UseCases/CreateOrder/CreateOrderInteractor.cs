using ClearArchitecture.Entities.Interfaces;
using ClearArchitecture.Entities.CAEntities;
using ClearArchitecture.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClearArchitecture.UseCasesPorts.CreateOrder;
using ClearArchitecture.UseCasesDTOs.CreateOrder;
using ClearArchitecture.UseCases.Common.Validators;
using FluentValidation;

namespace ClearArchitecture.UseCases.CreateOrder
{
    public class CreateOrderInteractor : ICreateOrderInputPort
    {
        readonly IOrderRepository OrderRepository;
        readonly IOrderDetailRepository OrderDetailRepository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateOrderOutputPort CreateOrderOutputPort;
        readonly IEnumerable<IValidator<CreateOrderParams>> Validators;
        public CreateOrderInteractor(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork, ICreateOrderOutputPort createOrderOutputPort, IEnumerable<IValidator<CreateOrderParams>> validators) =>
        (OrderRepository, OrderDetailRepository, UnitOfWork, CreateOrderOutputPort, Validators) = (orderRepository, orderDetailRepository, unitOfWork, createOrderOutputPort, validators);

        public async Task Handle(CreateOrderParams order)
        {
            await Validator<CreateOrderParams>.Validate(order, Validators); 

            Order Order = new Order
            {
                CustomerId = order.CustomerId,
                OrderDate = DateTime.Now,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipCountry = order.ShipCountry,
                ShipPostalCode = order.ShipPostalCode,
                ShippingType = Entities.Enums.ShippingType.Road,
                DiscountType = Entities.Enums.DiscountType.Percentage,
                Discount = 10
            };
            OrderRepository.Create(Order);
            foreach (var Item in order.OrderDetails)
            {
                OrderDetailRepository.Create(
                    new OrderDetail
                    {
                        Order = Order,
                        ProductId = Item.ProductId,
                        UnitPrice = Item.UnitPrice,
                        Quantity = Item.Quantity
                    });
            }
            try
            {
                await UnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al crear la orden.", ex.Message);
            }
            await CreateOrderOutputPort.Handle(Order.Id);
        }
    
    }
}
