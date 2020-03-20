using Application.Commands.ProductCommands;
using Application.Dto.Product;
using Application.Queries.ProductQueries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace JsonCommands.ProductCommands
{
    public class JsonGetProductsCommand : IGetProductsCommand
    {
        public IEnumerable<ProductDto> Execute(ProductQuery request)
        {
            var productJson = File.ReadAllText(@"..\JsonDataAccess\Product.json");
            return JsonConvert.DeserializeObject<List<ProductDto>>(productJson);
        }
    }
}
