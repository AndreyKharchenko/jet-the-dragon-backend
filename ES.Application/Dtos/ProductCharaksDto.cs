using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Dtos
{
    public class ProductCharaksDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
