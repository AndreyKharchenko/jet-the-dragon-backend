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
    internal sealed class TechMapRepository : Repository<TechMap>
    {
        public TechMapRepository(EsDbContext context) : base(context)
        {

        }

        public override async Task<TechMap> GetByIdAsync(Guid id)
        {
            var dbSet = DbContext.Set<TechMap>();
            return await dbSet.Include(s => s.TechMapJobs).Include(s => s.CriticalPath).FirstOrDefaultAsync(entity => entity.Id == id);
        }
        public override TechMap GetById(Guid id)
        {
            var dbSet = DbContext.Set<TechMap>();
            return dbSet.Include(s => s.TechMapJobs).Include(s => s.CriticalPath).FirstOrDefault(entity => entity.Id == id);
        }

        public override async Task<IEnumerable<TechMap>> GetByExpressionAsync(Expression<Func<TechMap, bool>> expression)
        {
            var dbSet = DbContext.Set<TechMap>();
            return await dbSet.Include(s => s.TechMapJobs).Where(expression).ToListAsync();
        }

        public override IEnumerable<TechMap> GetByExpression(Expression<Func<TechMap, bool>> expression)
        {
            var dbSet = DbContext.Set<TechMap>();
            return dbSet.Include(s => s.TechMapJobs).Where(expression).ToList();
        }
    }
}
