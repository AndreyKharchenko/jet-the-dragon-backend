using ES.Application.Dtos;
using ES.Application.Queries;
using ES.Application.UseCases;
using ES.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Persistence.QueryHandlers
{
    public class AnalyticQueryHandler : IHandler<AnalyticQuery, AnalyticDto>
    {
        private readonly EsDbContext _dbContext;


        public AnalyticQueryHandler(EsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AnalyticDto> HandleAsync(AnalyticQuery query, CancellationToken cancellation)
        {
            var supplierOrdersQuery = 
                _dbContext
                .Set<Order>()
                .Include(x => x.Product)
                    .ThenInclude(x => x.Supplier)
                .AsQueryable();

            supplierOrdersQuery = supplierOrdersQuery.Where(a => a.Product.SupplierId == query.SupplierId);

            return await supplierOrdersQuery.Select(x => new AnalyticDto()
            {
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                ProductCount = x.Product.Count,
                ProductSalesCount = 0,
                SupplierId = x.Product.SupplierId,
                
            }).GetListPageQuery(query).ToListAsync();
        }
    }
}
