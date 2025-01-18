using ES.Application.Commands.TechMapCommands;
using ES.Application.Infrastructure;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.TechMapCases
{
    internal class CreateTechMapCommandHandler : IHandler<CreateTechMapCommand, Guid>
    {
        private readonly IRepository<TechMap> _techMapRepository;
        private readonly IRepository<Supplier> _suppliersRepository;

        public CreateTechMapCommandHandler(IRepository<Supplier> suppliersRepository, IRepository<TechMap> techMapRepository)
        {
            _suppliersRepository = suppliersRepository;
            _techMapRepository = techMapRepository;
        }

        public async Task<Guid> HandleAsync(CreateTechMapCommand command, CancellationToken cancellation)
        {


            var supplier = await _suppliersRepository.GetByIdAsync(command.SupplierId);

            if (supplier is null)
            {
                throw new ApplicationException("Supplier not exist");
            }

            var techMap = new TechMap()
            {
                Id = Guid.NewGuid(),
                Supplier = supplier,
                SupplierId = supplier.Id,
                Name = command.Name
                /*JobName = command.JobName,
                JobDescription = command.JobDescription,
                JobDuration = command.JobDuration,
                JobDependence = command.JobDependence,
                JobResources = command.JobResources,
                JobCompleteDate = command.JobCompleteDate*/
            };

            techMap.TechMapJobs = new List<TechMapJobs>();

            foreach (var job in command.TechMapJobs)
            {
                techMap.TechMapJobs.Add(new TechMapJobs()
                {
                    // Id = Guid.NewGuid(),
                    Id = job.Id,
                    JobName = job.JobName,
                    JobDescription = job.JobDescription,
                    JobDuration = job.JobDuration,
                    JobDependence = job.JobDependence,
                    JobResources = job.JobResources,
                    JobCompleteDate = job.JobCompleteDate,
                    TechMapId = techMap.Id,
                    TechMap = techMap

                });
            }

            techMap.ComputeCriticalPath();

            _techMapRepository.Add(techMap);
            return techMap.Id;
        }
    }
}
