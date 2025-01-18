using ES.Application.Commands.CartCommands;
using ES.Application.Commands.CategoryCommands;
using ES.Application.Commands.CustomerCommands;
using ES.Application.Commands.DeliveredCommands;
using ES.Application.Commands.FavouriteCommands;
using ES.Application.Commands.FavouritiesCommands;
using ES.Application.Commands.ImageCommands;
using ES.Application.Commands.OrderCommands;
using ES.Application.Commands.PaymentCommands;
using ES.Application.Commands.ProductCommands;
using ES.Application.Commands.SupplierCommands;
using ES.Application.Commands.TechMapCommands;
using ES.Application.Dtos;
using ES.Application.Queries;
using ES.Application.Services;
using ES.Application.SeviceProvider;
using ES.Application.UseCases;
using ES.Application.UseCases.CartCases;
using ES.Application.UseCases.CategoryCases;
using ES.Application.UseCases.CustomerCases;
using ES.Application.UseCases.DeliveredCases;
using ES.Application.UseCases.FavouriteCases;
using ES.Application.UseCases.FavouritiesCases;
using ES.Application.UseCases.ImageCases;
using ES.Application.UseCases.OrderCases;
using ES.Application.UseCases.ProductCases;
using ES.Application.UseCases.SupplierCases;
using ES.Application.UseCases.TechMapCases;
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
            services.AddScoped<IHandler<DeleteProductCommand>, DeleteProductCommandHandler>();

            // Cart
            services.AddScoped<IHandler<CreateCartCommand, Guid>, CreateCartCommandHandler>();
            services.AddScoped<IHandler<UpdateCartCommand>, UpdateCartCommandHandler>();

            // Order
            services.AddScoped<IHandler<CreateOrderCommand, Guid>, CreateOrderCommandHandler>();
            services.AddScoped<IHandler<UpdateOrderCommand>, UpdateOrderCommandHandler>();
            services.AddScoped<IHandler<DeleteOrderCommand>, DeleteOrderCommandHandler>();

            // Favourite
            services.AddScoped<IHandler<CreateFavouriteCommand, Guid>, CreateFavouriteCommandHandler>();
            services.AddScoped<IHandler<UpdateFavouriteCommand>, UpdateFavouriteCommandHandler>();
            services.AddScoped<IHandler<DeleteFavouriteCommand>, DeleteFavouriteCommandHandler>();

            // Payment
            services.AddScoped<IHandler<CreatePaymentCommand>, CreatePaymentCommandHandler>();

            // Delivered
            services.AddScoped<IHandler<CreateDeliveredCommand>, CreateDeliveredCommandHandler>();

            // Images
            services.AddScoped<IHandler<CreateImagesCommand>, CreateImageCommandHandler>();
            services.AddScoped<IHandler<DeleteImageCommand>, DeleteImageCommandHandler>();

            // TechMap
            services.AddScoped<IHandler<CreateTechMapCommand, Guid>, CreateTechMapCommandHandler>();
            services.AddScoped<IHandler<UpdateTechMapCommand>, UpdateTechMapCommandHandler>();
            services.AddScoped<IHandler<DeleteTechMapCommand>, DeleteTechMapCommandHandler>();

            return services;
        }


        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IAppImageService, AppImageService>();

            services.AddScoped<IAuthCustomerProvider, AuthCustomerProvider>();

            services.AddScoped<IAuthSupplierProvider, AuthSupplierProvider>();

            return services;
        }

    }
}
