using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Product
{
    public class ProductInsertData
    {
        public List<Category> Categories { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Maker> Makers { get; set; }
    }
}
