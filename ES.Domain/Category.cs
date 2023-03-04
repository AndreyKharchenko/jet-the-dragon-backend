using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    public class Category: Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? CategoryImageId { get; set; }
    }
}
