using ES.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Persistence.QueryHandlers
{
    public static class ListQueryExtensions
    {
        public static IQueryable<T> GetListPageQuery<T>(this IQueryable<T> query, ListQuery listQuery) =>
        query.Skip(listQuery.PageIndex * listQuery.PageSize).Take(listQuery.PageSize);
    }
}
