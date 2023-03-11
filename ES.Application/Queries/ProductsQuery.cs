using ES.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Queries
{
    public sealed class ProductsQuery : ListQuery
    {
        /*public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? MaxCost { get; set; }
        public decimal? MinCost { get; set; }
        public Boolean IsStock { get; set; } = false;
        public Guid ProductImageId { get; set; }
        public DateTime ExpirationDate { get; set; }*/
        public Guid? CategoryId { get; set; }
        public int? MinShelfLife { get; set; }
        public int? MaxShelfLife { get; set; }
        public DateTime? MinManufactureDate { get; set; }
        public DateTime? MaxManufactureDate { get; set; }
        public decimal? MinRating { get; set; }
        public decimal? MaxRating { get; set; }
    }
}
