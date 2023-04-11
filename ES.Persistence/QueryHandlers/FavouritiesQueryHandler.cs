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
    public class FavouritiesQueryHandler : IHandler<FavouritiesQuery, IEnumerable<FavouritiesDto>>
    {
        private readonly EsDbContext _dbContext;

        public FavouritiesQueryHandler(EsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<FavouritiesDto>> HandleAsync(FavouritiesQuery query, CancellationToken cancellation)
        {
            var favouritiesQuery = _dbContext.Set<Favourities>().Include(x => x.Customer).AsQueryable(); // составляем SQL запрос SELECT * FROM Favourities

            favouritiesQuery = favouritiesQuery.Where(a => a.CustomerId == query.CustomerId);

            return await favouritiesQuery.Select(x => new FavouritiesDto()
            {
                Id = x.Id,
                CustomerId = x.CustomerId,
                ProductId = x.ProductId,
            }).GetListPageQuery(query).ToListAsync();


        }
    }
}
