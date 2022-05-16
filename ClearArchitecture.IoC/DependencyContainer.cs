using ClearArchitecture.Entities.Interfaces;
using ClearArchitecture.Presenters;
using ClearArchitecture.Repositories.EFCore.DataContext;
using ClearArchitecture.Repositories.EFCore.Repositories;
using ClearArchitecture.UseCases.Common.Validators;
using ClearArchitecture.UseCases.CreateOrder;
using ClearArchitecture.UseCasesPorts.CreateOrder;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearArchitecture.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddClearArchitectureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClearArchitectureContext>(options => options.UseSqlServer(configuration.GetConnectionString("ClearArchitectureDB")));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddScoped<ICreateOrderInputPort,CreateOrderInteractor>();
            services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();
            
            return services;
        }
    }
}
