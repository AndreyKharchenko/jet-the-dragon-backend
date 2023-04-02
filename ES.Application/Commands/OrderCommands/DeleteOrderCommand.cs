using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.OrderCommands
{
    public sealed class DeleteOrderCommand
    {
        [Required]
        public Guid OrderId { get; set; }
    }
}
