using Application.Commands.ProductCommands;
using Application.Dto.Product;
using Application.Queries.ProductQueries;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ProductCommands
{
    public class EfGetProductsCommand : BaseContext, IGetProductsCommand
    {
        public EfGetProductsCommand(Context context) : base(context)
        {
        }

        public IEnumerable<ProductDto> Execute(ProductQuery request)
        {
            var query = _context.Products.AsQueryable();
            return query.Select(p => new ProductDto
            {
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                CategoryName = p.Category.CategoryName,
                MakerName = p.Maker.MakerName,
                SupplierName = p.Supplier.SupplierName
            });
        }
    }
}
