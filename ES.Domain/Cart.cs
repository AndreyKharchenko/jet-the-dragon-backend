using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    public class Cart: Entity
    {
        public Guid CustomerId { get; init; }
        public Customer? Customer { get; init; }
        public int TotalCount { get; set; }
        public decimal TotalCost { get; set; }

        public string DeliveryType { get; set; }

        public string PaymentType { get; set; }

        public CartStatus Status { get; set; }

        public string Comment { get; set; }
    }
}
