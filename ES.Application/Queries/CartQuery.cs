using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Queries
{
    public sealed class CartQuery: ListQuery
    {
        public Guid CustomerId { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalCost { get; set; }
        public string DeliveryType { get; set; }

        public string PaymentType { get; set; }

        public string Status { get; set; }

        public string Comment { get; set; }
    }
}
