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
    public class CategoryQueryHandler : IHandler<CategoryQuery, IEnumerable<CategoryDto>>
    {
        
        private readonly EsDbContext _dbContext;

        public CategoryQueryHandler(EsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CategoryDto>> HandleAsync(CategoryQuery query, CancellationToken cancellation)
        {
            //return new List<CategoryDto>();
            var categoryQuery = _dbContext.Set<Category>().Where(x => true); // составляем SQL запрос SELECT * FROM Category
            
            return await categoryQuery.Select(x => new CategoryDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CategoryImageId = _dbContext.Set<Image>().Where(i => i.SubjectId == x.Id).Select(i => i.Id).FirstOrDefault(),
            }).GetListPageQuery(query).ToListAsync();
        }
    }
}
