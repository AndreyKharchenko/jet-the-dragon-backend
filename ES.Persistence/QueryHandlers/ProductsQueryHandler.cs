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
    public class ProductsQueryHandler : IHandler<ProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly EsDbContext _dbContext;

        public ProductsQueryHandler(EsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductDto>> HandleAsync(ProductsQuery query, CancellationToken cancellation)
        {
            //return new List<ProductDto>();
            var productQuery = _dbContext.Set<Product>().AsQueryable(); // составляем SQL запрос SELECT * FROM Products

            // Фильтры по значениям 
            if(query.CategoryId is not null)
            {
                productQuery = productQuery.Where(a => a.CategoryId == query.CategoryId);
            }

            return await productQuery.Select(x => new ProductDto()
            {
                CategoryId = x.CategoryId,
                SupplierId = x.SupplierId,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Count = x.Count,
                ShelfLife = x.ShelfLife,
                ManufactureDate = x.ManufactureDate,
                Rating = x.Rating,
                ProductCharaks = x.ProductCharaks.Select(y => new ProductCharaksDto()
                {
                    Key = y.Key,
                    Value = y.Value,
                    ProductId = y.ProductId,
                    Id = y.Id,
                }).ToArray(),
                ProductImages = _dbContext.Set<Image>().Where(i => i.SubjectId == x.Id).Select(i => i.Id).ToArray(),
            }).GetListPageQuery(query).ToListAsync();

               
        }
    }
}
