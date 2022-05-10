using ClearArchitecture.Presenters;
using ClearArchitecture.UseCases.CreateOrder;
using ClearArchitecture.UseCasesDTOs.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClearArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        readonly IMediator Mediator;
        public OrderController(IMediator mediator) =>
            Mediator = mediator;
        [HttpPost("create-order")]
        public async Task<string> CreateOrder(CreateOrderParams orderparams)
        {
            CreateOrderPresenter Presenter = new CreateOrderPresenter();
            await  Mediator.Send(new CreateOrderInputPort(orderparams,Presenter));
            return Presenter.Content;
        }
    }
}
