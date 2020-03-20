using Application.Commands.ProductCommands;
using Application.Dto.Product;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.ProductCommands
{
    public class EfGetProductCommand : BaseContext, IGetProductCommand
    {
        public EfGetProductCommand(Context context) : base(context)
        {
        }

        public ProductInsert Execute(long request)
        {
            int requestInt = Convert.ToInt32(request);
            var product = _context.Products.Find(requestInt);

            if (product == null)
                throw new EntityNotFoundException("Product");

            return new ProductInsert
            {
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                MakerId = product.MakerId,
                SupplierId = product.SupplierId
            };
        }
    }
}
