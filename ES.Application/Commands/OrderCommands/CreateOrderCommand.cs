using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.OrderCommands
{
    public sealed class CreateOrderCommand
    {
        [Required]
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }

        public DateTime CreateDate {get; set; }
        public Boolean isWholesale { get; set; }
    }
}
