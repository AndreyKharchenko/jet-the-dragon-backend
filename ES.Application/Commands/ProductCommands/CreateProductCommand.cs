using ES.Application.Dtos;
using ES.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Commands.ProductCommands
{
    public sealed class CreateProductCommand
    {
        [Required]
        /*public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile ProductImage { get; set; }

        public decimal Cost { get; set; }

        public Boolean IsStock { get; set; }

        public DateTime ExpirationDate { get; set; }*/

        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int ShelfLife { get; set; }
        public DateTime ManufactureDate { get; set; }
        public decimal Rating { get; set; }

        public string Unit { get; set; }
        public ProductCharaksDto[] ProductCharaks { get; set; }
    }
}
