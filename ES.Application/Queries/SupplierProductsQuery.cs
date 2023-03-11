using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Queries
{
    public sealed class SupplierProductsQuery : ListQuery
    {
        public Guid? CategoryId { get; set; }
        public int? MinShelfLife { get; set; }
        public int? MaxShelfLife { get; set; }
        public DateTime? MinManufactureDate { get; set; }
        public DateTime? MaxManufactureDate { get; set; }
        public decimal? MinRating { get; set; }
        public decimal? MaxRating { get; set; }
    }
}
