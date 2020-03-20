using Application.Commands.ProductCommands;
using Application.Dto.Product;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ProductCommands
{
    public class EfEditProductCommand : BaseContext, IEditProductCommand
    {
        public EfEditProductCommand(Context context) : base(context)
        {
        }

        public void Execute(ProductInsert request)
        {
            int requestIntId = Convert.ToInt32(request.Id);

            var product = _context.Products.Find(requestIntId);
            if (product == null)
                throw new EntityNotFoundException("Product");
        
            if(product.ProductName.ToLower().Replace(" ", string.Empty) 
                != request.ProductName.ToLower().Replace(" ", string.Empty))
            {
                if (_context.Products.Any(p => p.ProductName.ToLower().Replace(" ", string.Empty)
                                    == request.ProductName.ToLower().Replace(" ", string.Empty)))
                    throw new EntityAlreadyExistException("Product");
            }

            product.ProductName = request.ProductName;
            product.Description = request.Description;
            product.Price = request.Price;
            product.SupplierId = request.SupplierId;
            product.CategoryId = request.CategoryId;
            product.MakerId = request.MakerId;

            _context.SaveChanges();
        }
    }
}
