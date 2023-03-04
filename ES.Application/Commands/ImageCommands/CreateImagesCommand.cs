using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.ImageCommands
{
    public class CreateImagesCommand
    {
        public Guid SubjectId { get; set; }

        public IFormFile[] Images { get; set; }
    }
}
