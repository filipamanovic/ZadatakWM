using Application.Dto.Category;
using Application.Dto.Maker;
using Application.Dto.Supplier;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto.Product
{
    public class ProductInsertData
    {
        public List<CategoryDto> Categories { get; set; }
        public List<SupplierDto> Suppliers { get; set; }
        public List<MakerDto> Makers { get; set; }
    }
}
