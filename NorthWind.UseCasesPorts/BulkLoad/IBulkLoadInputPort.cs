using Microsoft.AspNetCore.Http;
using NorthWind.UseCasesDTOs.BulkLoad;
using System.Threading.Tasks;

namespace NorthWind.UseCasesPorts.BulkLoad
{
    public interface IBulkLoadInputPort
    {
        Task Handle(IFormFile file);
    }
}
