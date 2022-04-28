using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearArchitecture.Repositories.EFCore.DataContext
{
    class ClearArchitectureContextFactory:IDesignTimeDbContextFactory<ClearArchitectureContext>
    {
        public ClearArchitectureContext CreateDbContext(string[] args)
        {
            var OptionBuilder =
                new DbContextOptionsBuilder<ClearArchitectureContext>();
            OptionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=ClearArchitectureDB");
            return new ClearArchitectureContext(OptionBuilder.Options);
        }
    }
}
