using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dto.Product
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string MakerName { get; set; }
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
    }
}
