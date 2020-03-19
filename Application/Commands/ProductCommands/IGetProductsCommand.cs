using Application.Dto.Product;
using Application.Interfaces;
using Application.Queries.ProductQueries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ProductCommands
{
    public interface IGetProductsCommand : ICommand<ProductQuery, IEnumerable<ProductDto>>
    {
    }
}
