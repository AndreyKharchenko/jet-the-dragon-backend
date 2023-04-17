using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Dtos
{
    public sealed class AnalyticDto
    {
        public Guid SupplierId { get; set; }
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductProfit { get; set; }

        public decimal ProductSalesCount { get; set; }
    }
}
