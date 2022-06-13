using NorthWind.UseCasesDTOs.GetAllOrders;
using System.Threading.Tasks;

namespace NorthWind.UseCasesPorts.CreateOrder
{
    public interface IGetAllOrdersInputPort
    {
        Task Handle(GetAllOrdersParams order);
    }
}
