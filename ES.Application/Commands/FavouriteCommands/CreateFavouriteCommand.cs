using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.FavouritiesCommands
{
    public sealed class CreateFavouriteCommand
    {
        [Required]
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}
