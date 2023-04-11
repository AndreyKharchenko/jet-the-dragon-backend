using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Queries
{
    public sealed class OrderConfirmPayQuery : ListQuery
    {
        public Guid CustomerId { get; set; }
    }
}
