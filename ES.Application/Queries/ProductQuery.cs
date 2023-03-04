using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Queries
{
    public sealed class ProductQuery : ListQuery
    {
        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProductImageId { get; set; }

        public decimal? MaxCost { get; set; }
        public decimal? MinCost { get; set; }

        public Boolean IsStock { get; set; } = false;

        public DateTime ExpirationDate { get; set; }
    }
}
