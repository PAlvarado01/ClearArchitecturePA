using Microsoft.AspNetCore.Mvc;
using NorthWind.Presenters;
using NorthWind.UseCasesDTOs.CreateOrder;
using NorthWind.UseCasesPorts.CreateOrder;
using System.Threading.Tasks;

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly ICreateOrderInputPort InputPort;
        readonly ICreateOrderOutputPort OutputPort;
        public OrderController(ICreateOrderInputPort inputPort, ICreateOrderOutputPort outputPort)
        {
            this.InputPort = inputPort;
            this.OutputPort = outputPort;
        }

        [HttpPost("createOrder")]
        public async Task<string> CreateOrder(CreateOrderParams orderParams)
        {
            await InputPort.Handle(orderParams);
            var Presenter = OutputPort as CreateOrderPresenter;
            return Presenter.Content;
        }
    }
}
