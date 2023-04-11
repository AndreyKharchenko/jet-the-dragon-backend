using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.FavouriteCommands
{
    public sealed class DeleteFavouriteCommand
    {
        [Required]
        public Guid FavouriteId { get; set; }
    }
}
