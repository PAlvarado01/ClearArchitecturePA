using Microsoft.EntityFrameworkCore;
using NorthWind.Entities.POCOEntities;

namespace NorthWind.Repositories.EFCore.DataContext
{
    public class BulkLoadContext : DbContext
    {
        public BulkLoadContext(DbContextOptions<BulkLoadContext> options) : base(options)
        { }

        public DbSet<Archivo> Archivos { get; set; }
    }
}
