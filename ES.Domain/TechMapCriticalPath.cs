using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    public class TechMapCriticalPath: Entity
    {
        public Guid TechMapId { get; set; }
        public TechMap TechMap { get; set; }
        public int TotalDuration { get; set; }
        public ICollection<TechMapJobs> TechMapJobs { get; set; }
    }
}
