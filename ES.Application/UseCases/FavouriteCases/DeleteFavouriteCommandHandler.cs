using ES.Application.Commands.FavouriteCommands;
using ES.Application.Commands.OrderCommands;
using ES.Application.Infrastructure;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.FavouriteCases
{
    internal class DeleteFavouriteCommandHandler : IHandler<DeleteFavouriteCommand>
    {
        private readonly IRepository<Favourities> _favouritiesRepository;
        public DeleteFavouriteCommandHandler(IRepository<Favourities> favouritiesRepository)
        {
            _favouritiesRepository = favouritiesRepository;
        }

        public async Task HandleAsync(DeleteFavouriteCommand command, CancellationToken cancellation)
        {
            var favourite = await _favouritiesRepository.GetByIdAsync(command.FavouriteId);
            if (favourite is null)
            {
                throw new ApplicationException("Favourite not exist");
            }

            await _favouritiesRepository.RemoveAsync(favourite);

        }
    }
}
