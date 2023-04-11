using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    public class Entity
    {
        public Guid Id { get; set; }

        public EntityState State { get; set; }
    }
}
