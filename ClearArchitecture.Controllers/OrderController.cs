using ClearArchitecture.Presenters;
using ClearArchitecture.UseCases.CreateOrder;
using ClearArchitecture.UseCasesDTOs.CreateOrder;
using ClearArchitecture.UseCasesPorts.CreateOrder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClearArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly ICreateOrderInputPort InputPort;
        readonly ICreateOrderOutputPort OutputPort;
        public OrderController(ICreateOrderInputPort inputPort, ICreateOrderOutputPort outputPort) =>
            (InputPort, OutputPort) = (inputPort, outputPort);
        [HttpPost("create-order")]
        public async Task<string> CreateOrder(CreateOrderParams orderparams)
        {
            await InputPort.Handle(orderparams);
            var Presenter = OutputPort as CreateOrderPresenter;
            return Presenter.Content;
        }
    }
}
