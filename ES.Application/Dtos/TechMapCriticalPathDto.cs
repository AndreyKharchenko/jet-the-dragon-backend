using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Dtos
{
    public class TechMapCriticalPathDto
    {
        public Guid Id { get; set; }
        public Guid TechMapId { get; set; }
        public int TotalDuration { get; set; }
        public TechMapJobsDto[] TechMapJobs { get; set; }
    }
}
