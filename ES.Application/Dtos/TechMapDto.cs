using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Dtos
{
    public sealed class TechMapDto
    {

        public Guid Id { get; set; }
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public TechMapJobsDto[] TechMapJobs { get; set; }
        public TechMapCriticalPathDto CriticalPath { get; set; }
    }
}
