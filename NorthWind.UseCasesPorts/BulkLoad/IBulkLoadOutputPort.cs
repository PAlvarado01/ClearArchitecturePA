using NorthWind.UseCasesDTOs.BulkLoad;
using System.Threading.Tasks;

namespace NorthWind.UseCasesPorts.BulkLoad
{
    public interface IBulkLoadOutputPort
    {
        Task Handle(BulkLoadOutputPort outputPort);
    }
}
