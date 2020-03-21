using Application.Commands.ProductCommands;
using Application.Dto.Category;
using Application.Dto.Maker;
using Application.Dto.Product;
using Application.Dto.Supplier;
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
                Categories = _context.Categories.Select(c => new CategoryDto 
                {
                    CategoryName = c.CategoryName,
                    Id = c.Id
                }).ToList(),
                Makers = _context.Makers.Select(m => new MakerDto
                {
                    MakerName = m.MakerName,
                    Id = m.Id
                }).ToList(),
                Suppliers = _context.Suppliers.Select(s => new SupplierDto
                {
                    SupplierName = s.SupplierName,
                    Id = s.Id
                }).ToList()
            };
        }
    }
}
