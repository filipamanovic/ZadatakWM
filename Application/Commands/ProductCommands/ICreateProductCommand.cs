using Application.Dto.Product;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ProductCommands
{
    public interface ICreateProductCommand : ICommand<ProductInsert>
    {
    }
}
