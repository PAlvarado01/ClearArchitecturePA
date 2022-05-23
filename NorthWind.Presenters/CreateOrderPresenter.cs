using NorthWind.UseCasesPorts.CreateOrder;
using System.Threading.Tasks;

namespace NorthWind.Presenters
{
    public class CreateOrderPresenter : ICreateOrderOutputPort, IPresenter<string>
    {
        public string Content { get; private set; }

        public Task Handle(int orderId)
        {
            Content = $"Order Id: {orderId}";
            return Task.CompletedTask;
        }
    }
}
