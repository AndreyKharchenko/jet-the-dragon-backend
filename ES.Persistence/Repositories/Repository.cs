using ES.Application.Infrastructure;
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
    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        
        protected EsDbContext DbContext { get; init; }

        public Repository(EsDbContext context)
        {
            DbContext = context;
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            var dbSet = DbContext.Set<TEntity>();
            return await dbSet.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public virtual TEntity GetById(Guid id)
        {
            var dbSet = DbContext.Set<TEntity>();
            return dbSet.FirstOrDefault(entity => entity.Id == id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
        {
            var dbSet = DbContext.Set<TEntity>();
            return await dbSet.Where(expression).ToListAsync();
        }

        public virtual IEnumerable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression)
        {
            var dbSet = DbContext.Set<TEntity>();
            return dbSet.Where(expression).ToList();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            var dbSet = DbContext.Set<TEntity>();
            dbSet.Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            var dbSet = DbContext.Set<TEntity>();
            dbSet.Update(entity);
            DbContext.SaveChanges();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            var dbSet = DbContext.Set<TEntity>();
            await dbSet.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual void Add(TEntity entity)
        {
            var dbSet = DbContext.Set<TEntity>();
            dbSet.Add(entity);
            DbContext.SaveChanges();
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            var dbSet = DbContext.Set<TEntity>();
            dbSet.Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public virtual void Remove(TEntity entity)
        {
            var dbSet = DbContext.Set<TEntity>();
            dbSet.Remove(entity);
            DbContext.SaveChanges();
        }
    }
}
