using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Application.Dtos
{
    public sealed class OrderDto
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public decimal Cost { get; set; }

        public string ProductName { get; set; }
        public DateTime ProductManufactureDate { get; set; }
        public decimal ProductPrice { get; set; }

        public string ProductUnit { get; set; }

        public Guid ProductImage { get; set; }

        public Boolean isWholesale { get; set; }

        /*public DateTime CreateDate { get; set; }

        public string CartPaymentType { get; set; }
        public string CartDeliveryType { get; set; }
        public string SupplierAddres { get; set; }*/


    }
}
