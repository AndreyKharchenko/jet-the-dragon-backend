﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.OrderCommands
{
    public sealed class UpdateOrderCommand
    {
        [Required]
        public Guid OrderId { get; set; }
        public int Count { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
