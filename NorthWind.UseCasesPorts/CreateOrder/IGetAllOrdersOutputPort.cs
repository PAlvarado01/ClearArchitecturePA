using NorthWind.UseCasesDTOs.GetAllOrders;
using System.Threading.Tasks;

namespace NorthWind.UseCasesPorts.CreateOrder
{
    public interface IGetAllOrdersOutputPort
    {
        Task Handle(GetAllOrdersOutputPort outputPort);
    }

}
