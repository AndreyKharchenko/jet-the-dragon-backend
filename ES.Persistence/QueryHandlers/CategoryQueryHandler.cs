using ES.Application.Dtos;
using ES.Application.Queries;
using ES.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Persistence.QueryHandlers
{
    public class CategoryQueryHandler : IHandler<CategoryQuery, IEnumerable<CategoryDto>>
    {
        
        private readonly EsDbContext _dbContext;

        public CategoryQueryHandler(EsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryDto>> HandleAsync(CategoryQuery query, CancellationToken cancellation)
        {
            return new List<CategoryDto>();
        }
    }
}
