using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ES.Domain
{
    public class Product: Entity
    {
        /*public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public Category? Category { get; set; }
        public Supplier? Supplier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ProductImageId { get; set; }
        public decimal Cost { get; set; }
        public Boolean IsStock { get; set; }
        public DateTime ExpirationDate { get; set; }*/

        public Guid CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public Category? Category { get; set; }
        public Supplier? Supplier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int ShelfLife { get; set; }
        public DateTime ManufactureDate { get; set; }
        public decimal Rating { get; set; }
        public ICollection<ProductCharaks> ProductCharaks { get; set; }
        
    }
}
