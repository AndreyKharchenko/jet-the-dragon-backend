using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Infrastructure
{
    public interface IImageService
    {
        public Task<byte[]> GetImageBinaryAsync(Guid imageId);
        public Stream GetImageStream(Guid imageId);
        public Task SaveImageAsync(Stream imageStream, Guid imageId);
        public Task RemoveImageAsync(Guid imageId);
    }
}
