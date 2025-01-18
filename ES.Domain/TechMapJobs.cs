using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    public class TechMapJobs: Entity
    {
        public Guid TechMapId { get; set; }
        public TechMap TechMap { get; set; }

        public string JobName { get; set; }

        public string JobDescription { get; set; }

        public string JobDuration { get; set; }
        public string[] JobDependence { get; set; }

        public string JobResources { get; set; }

        public DateTime JobCompleteDate { get; set; }

        public int? Index { get; set; }
    }
}
