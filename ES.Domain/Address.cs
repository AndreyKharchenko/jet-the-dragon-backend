using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    public class Address
    {

        public string Country { get; set; }

        public string? Region { get; set; }
        public string City { get; set; }

        public string Street { get; set; }

        public string? PostalCode { get; set; }

        public string HouseNumber { get; set; }

        public string FlatNumber { get; set; }

    }
}
