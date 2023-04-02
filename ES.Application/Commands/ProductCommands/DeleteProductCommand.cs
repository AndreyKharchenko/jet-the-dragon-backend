using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.ProductCommands
{
    public sealed class DeleteProductCommand
    {
        public Guid ProductId { get; set; }
    }
}
