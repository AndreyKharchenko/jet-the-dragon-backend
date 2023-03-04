using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Services
{
    internal interface IAppImageService
    {
        Task<Guid> CreateImageAsync(Stream imageStream);
    }
}
