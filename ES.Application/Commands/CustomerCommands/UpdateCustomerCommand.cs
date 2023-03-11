using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.CustomerCommands
{
    public sealed class UpdateCustomerCommand
    {
        [Required]
        public Guid CustomerId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }

        public string FlatNumber { get; set; }

        public string? Region { get; set; }
    }
}
