using ES.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ES.Persistence.Repositories
{
    internal sealed class ProductRepository: Repository<Product>
    {
        public ProductRepository(EsDbContext context): base(context) 
        {
            
        }
        public override async Task<Product> GetByIdAsync(Guid id)
        {
            var dbSet = DbContext.Set<Product>();
            return await dbSet.Include(s => s.ProductCharaks).FirstOrDefaultAsync(entity => entity.Id == id);
        }
        public override Product GetById(Guid id)
        {
            var dbSet = DbContext.Set<Product>();
            return dbSet.Include(s => s.ProductCharaks).FirstOrDefault(entity => entity.Id == id);
        }

        public override async Task<IEnumerable<Product>> GetByExpressionAsync(Expression<Func<Product, bool>> expression)
        {
            var dbSet = DbContext.Set<Product>();
            return await dbSet.Include(s => s.ProductCharaks).Where(expression).ToListAsync();
        }

        public override IEnumerable<Product> GetByExpression(Expression<Func<Product, bool>> expression)
        {
            var dbSet = DbContext.Set<Product>();
            return dbSet.Include(s => s.ProductCharaks).Where(expression).ToList();
        }
    }
}
