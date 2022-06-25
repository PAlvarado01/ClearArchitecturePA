using Microsoft.AspNetCore.Http;
using NorthWind.UseCasesDTOs.BulkLoad;
using System.Threading.Tasks;

namespace NorthWind.UseCasesDTOs.BulkLoad
{
    public class BulkLoadParams
    {
        public IFormFile file { get; set; }
    }
}
