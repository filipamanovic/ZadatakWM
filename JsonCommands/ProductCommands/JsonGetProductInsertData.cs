using Application.Commands.ProductCommands;
using Application.Dto.Category;
using Application.Dto.Maker;
using Application.Dto.Product;
using Application.Dto.Supplier;
using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace JsonCommands.ProductCommands
{
    public class JsonGetProductInsertData : IGetProductInsertData
    {
        public ProductInsertData Execute()
        {
            var categoryJson = File.ReadAllText(@"..\JsonDataAccess\Category.json");
            var supplerJson = File.ReadAllText(@"..\JsonDataAccess\Supplier.json"); 
            var makerJson = File.ReadAllText(@"..\JsonDataAccess\Maker.json");
            return new ProductInsertData
            {
                Categories = JsonConvert.DeserializeObject<List<CategoryDto>>(categoryJson),
                Makers = JsonConvert.DeserializeObject<List<MakerDto>>(makerJson),
                Suppliers = JsonConvert.DeserializeObject<List<SupplierDto>>(supplerJson)
            };

        }
    }
}
