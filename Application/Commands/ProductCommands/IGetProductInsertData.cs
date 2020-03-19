using Application.Dto.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ProductCommands
{
    public interface IGetProductInsertData
    {
        ProductInsertData Execute();
    }
}
