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
    public class AnalyticQueryHandler : IHandler<AnalyticQuery, IEnumerable<AnalyticDto>>
    {
        private readonly EsDbContext _dbContext;


        public AnalyticQueryHandler(EsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AnalyticDto>> HandleAsync(AnalyticQuery query, CancellationToken cancellation)
        {
            var supplierOrdersQuery = 
                _dbContext
                .Set<Order>()
                .Include(x => x.Product)
                .AsQueryable();

            supplierOrdersQuery = supplierOrdersQuery.Where(a => a.Product.SupplierId == query.SupplierId);

            return await supplierOrdersQuery.GroupBy(x => x.Product, y => y, 
                (key,value) => new AnalyticDto()
                {
                    ProductId = key.Id,
                    ProductName = key.Name,
                    ProductSalesCount = value.Sum(x => x.Count),
                    ProductProfit = value.Sum(x => x.Cost),
                    SupplierId = key.SupplierId,
                }).GetListPageQuery(query).ToListAsync();
        }
    }
}
