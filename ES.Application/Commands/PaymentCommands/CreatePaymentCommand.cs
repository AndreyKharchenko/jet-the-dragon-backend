using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.PaymentCommands
{
    public sealed class CreatePaymentCommand
    {
        [Required]

        public Guid CartId { get; set; }
        public Boolean Payment { get; set; }
    }
}
