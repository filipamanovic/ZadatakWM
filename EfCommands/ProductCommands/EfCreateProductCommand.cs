using Application.Commands.ProductCommands;
using Application.Dto.Product;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ProductCommands
{
    public class EfCreateProductCommand : BaseContext, ICreateProductCommand
    {
        public EfCreateProductCommand(Context context) : base(context)
        {
        }

        public void Execute(ProductInsert request)
        {
            if (_context.Products.Any(p => p.ProductName.ToLower().Replace(" ", string.Empty) 
                                    == request.ProductName.ToLower().Replace(" ", string.Empty)))
                throw new EntityAlreadyExistException("Product");

            _context.Products.Add(new Product
            {
                ProductName = request.ProductName,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId,
                SupplierId = request.SupplierId,
                MakerId = request.MakerId
            });

            _context.SaveChanges();
        }
    }
}
