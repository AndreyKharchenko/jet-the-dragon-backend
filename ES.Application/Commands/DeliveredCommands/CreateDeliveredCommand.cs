using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.DeliveredCommands
{
    public sealed class CreateDeliveredCommand
    {
        [Required]

        public Guid CartId { get; set; }
        public Boolean Delivered { get; set; }
    }
}
