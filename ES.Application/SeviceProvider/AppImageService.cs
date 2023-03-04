using ES.Application.Infrastructure;
using ES.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.SeviceProvider
{
    internal sealed class AppImageService : IAppImageService
    {
        private readonly IImageService _imageService;

        public AppImageService(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<Guid> CreateImageAsync(Stream imageStream)
        {
            var imageId = Guid.NewGuid();
            await _imageService.SaveImageAsync(imageStream, imageId);

            return imageId;

        }

    }
}
