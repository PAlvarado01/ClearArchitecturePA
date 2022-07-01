using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Presenters;
using NorthWind.Presenters.GetAllOrdersDTO;
using NorthWind.UseCasesPorts.BulkLoad;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulkLoadController
    {
    readonly IBulkLoadInputPort InputPort;
    readonly IBulkLoadOutputPort OutputPort;

        public BulkLoadController(IBulkLoadInputPort inputPort, IBulkLoadOutputPort outputPort)
        {
            this.InputPort = inputPort;
            this.OutputPort = outputPort;
        }

        [HttpPost("BulkLoad")]
        public async Task<BulkLoadOutput> BulkLoad(IFormFile loadParams)
        {
            await InputPort.Handle(loadParams);
            var Presenter = OutputPort as BulkLoadPresenter;

            return Presenter.Content;
        }
    }
}
