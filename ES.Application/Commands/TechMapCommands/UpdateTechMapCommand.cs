using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ES.Application.Dtos;

namespace ES.Application.Commands.TechMapCommands
{
    public sealed class UpdateTechMapCommand
    {
        [Required]
        public Guid TechMapId { get; set; }

        public Guid? SupplierId { get; set; }

        public string? Name { get; set; }

        public TechMapJobsDto[]? TechMapJobs { get; set; }

        /*public string JobName { get; set; }

        public string JobDescription { get; set; }

        public string JobDuration { get; set; }

        public string JobDependence { get; set; }

        public string JobResources { get; set; }

        public DateTime JobCompleteDate { get; set; }*/

    }
}
