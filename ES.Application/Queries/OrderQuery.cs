using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Queries
{
    public sealed class OrderQuery : ListQuery
    {
        public string ProductName { get; set; }
        public int MaxCount { get; set; }
        public int MinCount { get; set; }

        public decimal MaxCost { get; set; }
        public decimal MinCost { get; set; }

    }
}
