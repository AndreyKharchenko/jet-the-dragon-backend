using ES.Application.Commands.SupplierCommands;
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
    internal class UpdateTechMapCommandHandler : IHandler<UpdateTechMapCommand>
    {
        private readonly IRepository<TechMap> _techMapRepository;
        public UpdateTechMapCommandHandler(IRepository<TechMap> techMapRepository)
        {
            _techMapRepository = techMapRepository;
        }

        public async Task HandleAsync(UpdateTechMapCommand command, CancellationToken cancellation)
        {
            var techMap = await _techMapRepository.GetByIdAsync(command.TechMapId);

            var isChanged = false;

            if (command.Name is not null && command.Name != techMap.Name)
            {
                techMap.Name = command.Name;
                isChanged = true;
            }

            if (command.TechMapJobs is not null)
            {

                techMap.TechMapJobs.Clear();

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

                isChanged = true;
            }

            if (isChanged)
            {
                //techMap.ComputeCriticalPath();
                await _techMapRepository.UpdateAsync(techMap);
            }
        }
    }
}
