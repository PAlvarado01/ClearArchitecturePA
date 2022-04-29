using ClearArchitecture.UseCases.CreateOrder;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClearArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator Mediator;
        public OrderController(IMediator mediator) =>
            Mediator = mediator;
        [HttpPost("create-order")]
        public async Task<ActionResult<int>> CreateOrder(CreateOrderInputPort orderparams)
        {
            return await Mediator.Send(orderparams);
        }
    }
}
