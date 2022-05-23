using NorthWind.Presenters.GetAllOrdersDTO;
using NorthWind.UseCasesPorts.CreateOrder;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Presenters
{
    public class GetAllOrdersPresenter : IGetAllOrdersOutputPort, IPresenter<GetAllOrdersOutput>
    {
        public GetAllOrdersOutput Content { get; private set; }
        public List<GetAllOrder> Orders { get ; set; }

        public void Handler(IGetAllOrdersOutputPort response)
        {
            var orders = response.Orders
                .Select(s => new Order
                {
                    OrderDate = s.OrderDate,
                    ShipAddress = s.ShipAddress,
                    ShipCity = s.ShipCity,
                    ShipCountry = s.ShipCountry,
                    ShipPostalCode = s.ShipPostalCode,
                    DiscountType = s.DiscountType,
                    Discount = s.Discount,
                    shippingType = s.shippingType,
                    OrderDetails = s.OrderDetails
                        .Select(od => new OrderDetail
                        {
                            Product = od.Product,
                            UnitPrice = od.UnitPrice,
                            Quantity = od.Quantity
                        }).ToList()
                })
                .ToList();

            Content = new GetAllOrdersOutput() 
            { 
                Orders = orders 
            };
        }
    }
}
