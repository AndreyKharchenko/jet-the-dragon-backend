﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.FavouritiesCommands
{
    public sealed class UpdateFavouriteCommand
    {
        [Required]
        public Guid FavouriteId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? ProductId { get; set; }
    }
}
