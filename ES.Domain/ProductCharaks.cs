using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    public class ProductCharaks: Entity
    {

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}
