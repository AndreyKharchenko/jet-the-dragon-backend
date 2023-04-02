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
    internal class OrderRepository : Repository<Order>
    {
        public OrderRepository(EsDbContext context) : base(context)
        {

        }
        public override async Task<Order> GetByIdAsync(Guid id)
        {
            var dbSet = DbContext.Set<Order>();
            return await dbSet
                .Include(s => s.Product)
                .Include(s => s.Cart)
                .FirstOrDefaultAsync(entity => entity.Id == id);
        }
        public override Order GetById(Guid id)
        {
            var dbSet = DbContext.Set<Order>();
            return dbSet
                .Include(s => s.Product)
                .Include(s => s.Cart)
                .FirstOrDefault(entity => entity.Id == id);
        }

        public override async Task<IEnumerable<Order>> GetByExpressionAsync(Expression<Func<Order, bool>> expression)
        {
            var dbSet = DbContext.Set<Order>();
            return await dbSet
                .Include(s => s.Product)
                .Include(s => s.Cart)
                .Where(expression).ToListAsync();
        }

        public override IEnumerable<Order> GetByExpression(Expression<Func<Order, bool>> expression)
        {
            var dbSet = DbContext.Set<Order>();
            return dbSet
                .Include(s => s.Product)
                .Include(s => s.Cart)
                .Where(expression).ToList();
        }
    }
}
