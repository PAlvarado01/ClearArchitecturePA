using ClearArchitecture.Entities.Interfaces;
using ClearArchitecture.Repositories.EFCore.DataContext;
using ClearArchitecture.Repositories.EFCore.Repositories;
using ClearArchitecture.UseCases.Common.Behaviors;
using ClearArchitecture.UseCases.CreateOrder;
using FluentValidation;
using MediatR;
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

            services.AddMediatR(typeof(CreateOrderInteractor));
            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
