using Application.Commands.SupplierCommands;
using Application.Dto.Supplier;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.SupplierCommands
{
    public class EfCreateSupplierCommand : BaseContext, ICreateSupplierCommand
    {
        public EfCreateSupplierCommand(Context context) : base(context)
        {
        }

        public void Execute(SupplierDto request)
        {
            _context.Suppliers.Add(new Supplier
            {
                SupplierName = request.SupplierName
            });

            _context.SaveChanges();
        }
    }
}
