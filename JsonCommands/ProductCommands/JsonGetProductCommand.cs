using Application.Commands.ProductCommands;
using Application.Dto.Product;
using Application.Exceptions;
using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JsonCommands.ProductCommands
{
    public class JsonGetProductCommand : IGetProductCommand
    {
        public ProductInsert Execute(long request)
        {
            var products = JsonConvert.DeserializeObject<List<ProductDto>>
                    (File.ReadAllText(@"..\JsonDataAccess\Product.json"));

            var product = products.Where(p => p.Id == request).First();
            if (product == null)
                throw new EntityNotFoundException("Product");

            var categoryId = JsonConvert.DeserializeObject<List<Category>>
                (File.ReadAllText(@"..\JsonDataAccess\Category.json"))
                .Where(c => c.CategoryName.ToLower().Replace(" ", string.Empty) 
                == product.CategoryName.ToLower().Replace(" ", string.Empty)).Select(c => c.Id).First();
            var supplierId = JsonConvert.DeserializeObject<List<Supplier>>
                (File.ReadAllText(@"..\JsonDataAccess\Supplier.json"))
                .Where(s => s.SupplierName.ToLower().Replace(" ", string.Empty) 
                == product.SupplierName.ToLower().Replace(" ", string.Empty)).Select(c => c.Id).First();
            var makerId = JsonConvert.DeserializeObject<List<Maker>>
                (File.ReadAllText(@"..\JsonDataAccess\Maker.json"))
                .Where(m => m.MakerName.ToLower().Replace(" ", string.Empty) 
                == product.MakerName.ToLower().Replace(" ", string.Empty)).Select(c => c.Id).First();

            return new ProductInsert
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                SupplierId = supplierId,
                MakerId = makerId,
                CategoryId = categoryId
            };
        }
    }
}
