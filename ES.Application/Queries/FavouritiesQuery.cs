using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Queries
{
    public sealed class FavouritiesQuery : ListQuery
    {
        //public Guid FavouriteId { get; set; }
        public Guid CustomerId { get; set; }

    }
}
