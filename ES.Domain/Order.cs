using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    public class Order: Entity
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid CartId { get; set; }
        public Cart? Cart { get; set; }

        public int Count { get; set; }

        public decimal Cost { get; set; }

        public DateTime CreateDate { get; set; }

        public Boolean isWholesale { get; set; }

    }
}
