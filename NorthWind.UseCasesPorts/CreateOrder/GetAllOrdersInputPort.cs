using NorthWind.UseCasesDTOs.GetAllOrders;
using System.Threading.Tasks;

namespace NorthWind.UseCasesPorts.CreateOrder
{
    public interface GetAllOrdersInputPort
    {
        Task Handle(GetAllOrdersParams order);
    }
}
