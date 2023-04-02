using ES.Application.Dtos;
using ES.Application.Queries;
using ES.Application.UseCases;
using ES.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Persistence.QueryHandlers
{
    public class OrdersQueryHandler : IHandler<OrderQuery, IEnumerable<OrderDto>>
    {
        private readonly EsDbContext _dbContext;

        public OrdersQueryHandler(EsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OrderDto>> HandleAsync(OrderQuery query, CancellationToken cancellation)
        {
            var orderQuery = _dbContext.Set<Order>().Include(x => x.Product).AsQueryable(); // составляем SQL запрос SELECT * FROM Order

            if(query.CartId is not null) 
            { 
                orderQuery = orderQuery.Where(a => a.CartId == query.CartId);
            }

            // Product Name  
            if(query.ProductName is not null)
            {
                orderQuery = orderQuery.Where(a => a.Product.Name == query.ProductName);
            }

            // Max and Min Count
            if (query.MaxCount is not null)
            {
                orderQuery = orderQuery.Where(a => (a.Count <= query.MaxCount));
            }


            if (query.MinCount is not null)
            {
                orderQuery = orderQuery.Where(a => (a.Count >= query.MinCount));
            }

            // Max and Min Cost
            if (query.MaxCost is not null)
            {
                orderQuery = orderQuery.Where(a => (a.Cost <= query.MaxCost));
            } 


            if (query.MinCost is not null)
            {
                orderQuery = orderQuery.Where(a => (a.Cost >= query.MinCost));
            }


            return await orderQuery.Select(x => new OrderDto()
            {
                Id = x.Id,
                CartId = x.CartId,
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                ProductManufactureDate = x.Product.ManufactureDate,
                ProductPrice = x.Product.Price,
                ProductUnit = x.Product.Unit,
                Count = x.Count,
                Cost = x.Cost,
            }).GetListPageQuery(query).ToListAsync();

               
        }
    }
}
