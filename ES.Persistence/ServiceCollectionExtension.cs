using ES.Application.Commands.CategoryCommands;
using ES.Application.Dtos;
using ES.Application.Queries;
using ES.Application.UseCases;
using ES.Application.UseCases.CartCases;
using ES.Application.UseCases.CategoryCases;
using ES.Domain;
using ES.Persistence.QueryHandlers;
using ES.Persistence.Repositories;
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
        public static IServiceCollection AddQueryHandlers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHandler<CategoryQuery, IEnumerable<CategoryDto>>, CategoryQueryHandler>();
            services.AddScoped<IHandler<CustomerQuery, CustomerDto>, CustomerQueryHandler>();
            services.AddScoped<IHandler<SupplierQuery, SupplierDto>, SupplierQueryHandler>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository<Category>, GenericRepository<Category>>();
            services.AddScoped<IRepository<Customer>, GenericRepository<Customer>>();
            services.AddScoped<IRepository<Supplier>, SupplierRepository>();
            return services;
        }
    }
}
