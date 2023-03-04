using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    public class Image: Entity
    {
        public Guid SubjectId { get; set; }
    }
}
