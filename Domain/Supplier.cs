using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Supplier : BaseEntity
    {
        public string SupplierName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
