using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NorthWind.Repositories.EFCore.DataContext
{
    public class NorthWindContextFactory : IDesignTimeDbContextFactory<NorthWindContext>
    {
        public NorthWindContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<NorthWindContext>();
            optionBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ClearArchitectureDB;Integrated Security=True;");

            return new NorthWindContext(optionBuilder.Options);
            //add-migration InitialCreate1 -p NorthWind.Repositories.EFCore -c NorthWindContext -o Migrations -s NorthWind.Repositories.EFCore
            // -p : Default project // -c : Context data // -o : place folder // -s : initial project or tools to start
            //update-database -p NorthWind.Repositories.EFCore -s NorthWind.Repositories.EFCore
            //remove - migration - p NorthWind.Repositories.EFCore - s NorthWind.Repositories.EFCore
        }
    }
}
