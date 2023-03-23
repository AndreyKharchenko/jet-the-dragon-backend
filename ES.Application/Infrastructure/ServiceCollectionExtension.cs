using ES.Application.Commands.CartCommands;
using ES.Application.Commands.CategoryCommands;
using ES.Application.Commands.CustomerCommands;
using ES.Application.Commands.ProductCommands;
using ES.Application.Commands.SupplierCommands;
using ES.Application.Dtos;
using ES.Application.Queries;
using ES.Application.Services;
using ES.Application.SeviceProvider;
using ES.Application.UseCases;
using ES.Application.UseCases.CartCases;
using ES.Application.UseCases.CategoryCases;
using ES.Application.UseCases.CustomerCases;
using ES.Application.UseCases.ProductCases;
using ES.Application.UseCases.SupplierCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Infrastructure
{
    public static class ServiceCollectionExtension    
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services, IConfiguration configuration)
        {
            // Category
            services.AddScoped<IHandler<CreateCategoryCommand, Guid>, CreateCategoryCommandHandler>();
            services.AddScoped<IHandler<UpdateCategoryCommand>, UpdateCategoryCommandHandler>();

            // Customer
            services.AddScoped<IHandler<CreateCustomerCommand, Guid>, CreateCustomerCommandHandler>();
            services.AddScoped<IHandler<UpdateCustomerCommand>, UpdateCustomerCommandHandler>();

            // Supplier
            services.AddScoped<IHandler<CreateSupplierCommand, Guid>, CreateSupplierCommandHandler>();
            services.AddScoped<IHandler<UpdateSupplierCommand>, UpdateSupplierCommandHandler>();

            // Product
            services.AddScoped<IHandler<CreateProductCommand, Guid>, CreateProductCommandHandler>();
            services.AddScoped<IHandler<UpdateProductCommand>, UpdateProductCommandHandler>();

            // Cart
            //services.AddScoped<IHandler<CreateCartCommand, Guid>, CreateCartCommandHandler>();
            //services.AddScoped<IHandler<UpdateCartCommand>, UpdateCartCommandHandler>();

            return services;
        }


        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IAppImageService, AppImageService>();

            return services;
        }

    }
}
