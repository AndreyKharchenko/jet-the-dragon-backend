﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.SupplierCommands
{
    public sealed class UpdateSupplierCommand
    {
        [Required]
        public Guid SupplierId { get; set; }
        /*public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }*/

        public string OrgType { get; set; }

        public string INN { get; set; }

        public string Name { get; set; }

        public string OGRNIP { get; set; }

        public string DeclarationNum { get; set; }

        public DateTime DeclarationDate { get; set; }

        public string SanBookNum { get; set; }

        public DateTime SanBookDate { get; set; }
        public string Description { get; set; }

    }
}
