using ES.Application.Commands.ImageCommands;
using ES.Application.Commands.ProductCommands;
using ES.Application.Commands.SupplierCommands;
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
    internal class CreateImageCommandHandler : IHandler<CreateImagesCommand>
    {
        
        private readonly IRepository<Image> _imagesRepository;
        private readonly IAppImageService _appImageService;
        public CreateImageCommandHandler(IRepository<Image> imagesRepository, IAppImageService appImageService)
        {
            _appImageService = appImageService;
            _imagesRepository = imagesRepository;
        }

        public async Task HandleAsync(CreateImagesCommand command, CancellationToken cancellation)
        {
            Guid? imageId = null;

            foreach(var img in command.Images)
            {
                imageId = await _appImageService.CreateImageAsync(img.OpenReadStream());
                var image = new Image()
                {
                    SubjectId = command.SubjectId,
                    Id = imageId.Value,
                };

                _imagesRepository.Add(image);
            }
        }
    }
}
