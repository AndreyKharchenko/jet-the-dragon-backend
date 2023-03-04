using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Dtos
{
    public sealed class FavouritiesDto
    {
        public Guid FavouritiesId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}
