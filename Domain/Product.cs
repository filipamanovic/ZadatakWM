using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int MakerId { get; set; }
        public Maker Maker { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
