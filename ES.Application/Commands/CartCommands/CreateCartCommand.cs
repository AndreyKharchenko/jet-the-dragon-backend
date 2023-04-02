using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.CartCommands
{
    public sealed class CreateCartCommand
    {
        
        public string DeliveryType { get; set; }

        public string PaymentType { get; set; }

        public string Comment { get; set; }
    }
}
