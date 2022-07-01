using NorthWind.Entities.Interfaces;
using NorthWind.Entities.POCOEntities;
using NorthWind.Entities.Specifications;
using NorthWind.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NorthWind.Repositories.EFCore.Repositories
{
    public class BulkLoadRepository : IBulkLoadRepository
    {
        readonly NorthWindContext context;

        public BulkLoadRepository(NorthWindContext context)
        {
            this.context = context;
        }
        public void Create(Archivo archivo)
        {
            context.Add(archivo);
        }

        public void Upload(string fileName, string base64, string destLocalPath)
        {
            File.WriteAllBytes($"{destLocalPath}{fileName}", Convert.FromBase64String(base64));
        }

        public IEnumerable<Archivo> GetBulkLoadByEspecification(Specification<Archivo> specification)
        {
            var expressionDelegate = specification.Expression.Compile();
            return context.Archivos.Where(expressionDelegate);
        }
        
    }
}
