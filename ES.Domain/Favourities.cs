using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    public class Favourities: Entity
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public Customer? Customer { get; set; }
        public Product? Product { get; set; }
    }
}
