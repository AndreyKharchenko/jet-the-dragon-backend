using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Queries
{
    public sealed class TechMapQuery: ListQuery
    {
        public Guid SupplierId { get; set; }
    }
}
