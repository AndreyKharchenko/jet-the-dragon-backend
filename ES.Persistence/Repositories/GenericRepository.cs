using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Persistence.Repositories
{
    
    
    internal sealed class GenericRepository<TEntity> : Repository<TEntity> where TEntity : Entity
    {
        public GenericRepository(EsDbContext context) : base(context)
        {
        }
    }
   
}
