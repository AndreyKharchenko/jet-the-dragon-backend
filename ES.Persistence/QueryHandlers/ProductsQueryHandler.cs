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

            if (query.SupplierId is not null)
            {
                productQuery = productQuery.Where(a => a.SupplierId == query.SupplierId);
            }

            // ShelfLife
            if (query.MinShelfLife is not null)
            {
                productQuery = productQuery.Where(a => (a.ShelfLife >= query.MinShelfLife));
            }

            if (query.MaxShelfLife is not null)
            {
                productQuery = productQuery.Where(a => (a.ShelfLife <= query.MaxShelfLife));
            }

            // Manufacture date
            if (query.MinManufactureDate is not null)
            {
                productQuery = productQuery.Where(a => (a.ManufactureDate >= query.MinManufactureDate));
            }

            if (query.MaxManufactureDate is not null)
            {
                productQuery = productQuery.Where(a => (a.ManufactureDate <= query.MaxManufactureDate));
            }

            // Rating

            if (query.MinRating is not null)
            {
                productQuery = productQuery.Where(a => (a.Rating >= query.MinRating));
            }

            if (query.MaxRating is not null)
            {
                productQuery = productQuery.Where(a => (a.Rating <= query.MaxRating));
            }

            return await productQuery.Select(x => new ProductDto()
            {
                Id = x.Id,
                CategoryId = x.CategoryId,
                SupplierId = x.SupplierId,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Count = x.Count,
                ShelfLife = x.ShelfLife,
                ManufactureDate = x.ManufactureDate,
                Rating = x.Rating,
                Unit = x.Unit,
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
