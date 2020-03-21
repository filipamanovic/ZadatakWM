using Application.Dto.Supplier;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.SupplierCommands
{
    public interface ICreateSupplierCommand : ICommand<SupplierDto>
    {
    }
}
