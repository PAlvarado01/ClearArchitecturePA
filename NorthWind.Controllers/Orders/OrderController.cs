using Microsoft.AspNetCore.Mvc;
using NorthWind.Presenters;
using NorthWind.Presenters.GetAllOrdersDTO;
using NorthWind.UseCases.GetAllOrders;
using NorthWind.UseCasesDTOs.GetAllOrders;
using NorthWind.UseCasesPorts.CreateOrder;
using System.Threading.Tasks;

namespace NorthWind.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly IGetAllOrdersInputPort InputPort;
        readonly IGetAllOrdersOutputPort OutputPort;
        public OrderController(IGetAllOrdersInputPort inputPort, IGetAllOrdersOutputPort outputPort)
        {
            this.InputPort = inputPort;
            this.OutputPort = outputPort;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetAllOrdersOutput), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [Route("GetAllOrdersByCustomer")]
        public async Task<GetAllOrdersOutput> GetAllOrdersByCustomer(GetAllOrdersParams order)
        {
            await InputPort.Handle(order);

            var Presenter = OutputPort as GetAllOrdersPresenter;
            return Presenter.Content;
        }
    }
}
