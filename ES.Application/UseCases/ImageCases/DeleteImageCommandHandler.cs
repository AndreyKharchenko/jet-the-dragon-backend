using ES.Application.Commands.ImageCommands;
using ES.Application.Infrastructure;
using ES.Application.Services;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.UseCases.ImageCases
{
    internal class DeleteImageCommandHandler
    {
        private readonly IRepository<Image> _imagesRepository;
        private readonly IAppImageService _appImageService;
        public DeleteImageCommandHandler(IRepository<Image> imagesRepository, IAppImageService appImageService)
        {
            _appImageService = appImageService;
            _imagesRepository = imagesRepository;
        }

        public async Task HandleAsync(DeleteImageCommand command, CancellationToken cancellation)
        {
            var image = await _imagesRepository.GetByIdAsync(command.ImageId);

            await _imagesRepository.RemoveAsync(image);

            
        }
    }
}
