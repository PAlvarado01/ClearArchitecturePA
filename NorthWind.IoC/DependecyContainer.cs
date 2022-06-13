using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces;
using NorthWind.Presenters;
using NorthWind.Repositories.EFCore.DataContext;
using NorthWind.Repositories.EFCore.Repositories;
using NorthWind.UseCases.Common.Validators;
using NorthWind.UseCases.CreateOrder;
using NorthWind.UseCases.GetAllOrders;
using NorthWind.UseCasesPorts.CreateOrder;

namespace NorthWind.IoC
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddNorthWindService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<NorthWindContext>(options => options.UseSqlServer(configuration.GetConnectionString("NorthWindDB")));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(GetAllOrdersValidator).Assembly);

            // Create Order
            services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();
            services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();

            //Get Orders By Customer
            services.AddScoped<IGetAllOrdersInputPort, GetAllOrdersInteractor>();
            services.AddScoped<IGetAllOrdersOutputPort, GetAllOrdersPresenter>();

            return services;
        }
    }
}
