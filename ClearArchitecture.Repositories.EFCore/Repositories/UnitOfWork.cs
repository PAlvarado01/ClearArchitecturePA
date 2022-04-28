using ClearArchitecture.Entities.Interfaces;
using ClearArchitecture.Repositories.EFCore.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearArchitecture.Repositories.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ClearArchitectureContext Context;
        public UnitOfWork(ClearArchitectureContext context) =>
            Context = context;
        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
