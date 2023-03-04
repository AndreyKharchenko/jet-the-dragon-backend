using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Queries
{
    public sealed class CustomersQuery: ListQuery
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
