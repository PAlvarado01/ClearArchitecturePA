using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;
using System.Collections.Generic;

namespace NorthWind.Entities.Interfaces
{
    public interface IBulkLoadRepository
    {
        void Create(Archivo archivo);

        void Upload(string fileName, string base64, string destLocalPath);

        IEnumerable<Archivo> GetBulkLoadByEspecification(Specification<Archivo> specification);
    }
}
