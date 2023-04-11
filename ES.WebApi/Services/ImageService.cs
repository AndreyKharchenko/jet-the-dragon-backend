using ES.Application.Infrastructure;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ES.WebApi.Services
{
    public class ImageService : IImageService
    {
        private const int MaxImageSide = 1024;

        /*private readonly Microsoft.AspNetCore.Hosting.IWebHostingEnvironment _environment;

        public ImageService(Microsoft.AspNetCore.Hosting.IWebHostingEnvironment environment)
        {
            _environment = environment;
        }*/

        public async Task<byte[]> GetImageBinaryAsync(Guid imageId)
        {
            //var fileName = $"C:/Users/Kharc/Документы/ESImages/{imageId}.png";
            var fileName = $"C:/Users/Kharc/source/repos/jet-the-dragon-backend/ES.WebApi/wwwroot/Images/{imageId}.png";
            

            if (File.Exists(fileName))
                return await File.ReadAllBytesAsync(fileName);

            return null;
        }

        public Stream GetImageStream(Guid imageId)
        {
            //var fileName = $"C:/Users/Kharc/Документы/ESImages/{imageId}.png";
            var fileName = $"C:/Users/Kharc/source/repos/jet-the-dragon-backend/ES.WebApi/wwwroot/Images/{imageId}.png";

            if (File.Exists(fileName))
                return new FileStream(fileName, FileMode.Open, FileAccess.Read);

            return null;
        }

        public Task RemoveImageAsync(Guid imageId)
        {
            //var fileName = $"C:/Users/Kharc/Документы/ESImages/{imageId}.png";
            var fileName = $"C:/Users/Kharc/source/repos/jet-the-dragon-backend/ES.WebApi/wwwroot/Images/{imageId}.png";

            if (File.Exists(fileName))
                File.Delete(fileName);

            return Task.CompletedTask;
        }

        public async Task SaveImageAsync(Stream imageStream, Guid imageId)
        {
            var image = await Image.LoadAsync(imageStream);
            var maxSide = Math.Max(image.Width, image.Height);
            if (maxSide > MaxImageSide)
                image.Mutate(x => x.Resize(image.Width * MaxImageSide / maxSide, image.Height * MaxImageSide / maxSide));

            var fileName = $"C:/Users/Kharc/source/repos/jet-the-dragon-backend/ES.WebApi/wwwroot/Images/{imageId}.png";

            image.SaveAsPngAsync(fileName);
        }
    }
}
