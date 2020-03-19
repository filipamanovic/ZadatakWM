using Application.Commands.ProductCommands;
using Application.Dto.Product;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ProductCommands
{
    public class EfGetProductInsertData : BaseContext, IGetProductInsertData
    {
        public EfGetProductInsertData(Context context) : base(context)
        {
        }

        public ProductInsertData Execute()
        {
            return new ProductInsertData
            {
                Categories = _context.Categories.Select(c => new Category 
                {
                    CategoryName = c.CategoryName,
                    Id = c.Id
                }).ToList(),
                Makers = _context.Makers.Select(m => new Maker
                {
                    MakerName = m.MakerName,
                    Id = m.Id
                }).ToList(),
                Suppliers = _context.Suppliers.Select(s => new Supplier
                {
                    SupplierName = s.SupplierName,
                    Id = s.Id
                }).ToList()
            };
        }
    }
}
