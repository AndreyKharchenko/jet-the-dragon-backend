using ES.Application.Commands.ProductCommands;
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
    internal class DeleteTechMapCommandHandler : IHandler<DeleteTechMapCommand>
    {
        private readonly IRepository<TechMap> _techMapRepository;
        public DeleteTechMapCommandHandler(IRepository<TechMap> techMapRepository)
        {
            _techMapRepository = techMapRepository;
        }

        public async Task HandleAsync(DeleteTechMapCommand command, CancellationToken cancellation)
        {
            var techMap = await _techMapRepository.GetByIdAsync(command.TechMapId);

            if (techMap is null)
            {
                throw new ApplicationException("Tech map not exist");
            }

            techMap.State = EntityState.Removed;

            await _techMapRepository.UpdateAsync(techMap);
        }
    }
}
