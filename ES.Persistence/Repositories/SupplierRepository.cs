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
    internal sealed class SupplierRepository: Repository<Supplier>
    {
        public SupplierRepository(EsDbContext context): base(context) 
        {
            
        }
        public override async Task<Supplier> GetByIdAsync(Guid id)
        {
            var dbSet = DbContext.Set<Supplier>();
            return await dbSet.Include(s => s.Customer).FirstOrDefaultAsync(entity => entity.Id == id);
        }
        public override Supplier GetById(Guid id)
        {
            var dbSet = DbContext.Set<Supplier>();
            return dbSet.Include(s => s.Customer).FirstOrDefault(entity => entity.Id == id);
        }

        public override async Task<IEnumerable<Supplier>> GetByExpressionAsync(Expression<Func<Supplier, bool>> expression)
        {
            var dbSet = DbContext.Set<Supplier>();
            return await dbSet.Include(s => s.Customer).Where(expression).ToListAsync();
        }

        public override IEnumerable<Supplier> GetByExpression(Expression<Func<Supplier, bool>> expression)
        {
            var dbSet = DbContext.Set<Supplier>();
            return dbSet.Include(s => s.Customer).Where(expression).ToList();
        }
    }
}
