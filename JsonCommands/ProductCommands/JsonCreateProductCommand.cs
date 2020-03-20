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
    public class JsonCreateProductCommand : ICreateProductCommand
    {
        public void Execute(ProductInsert request)
        {
            var products = JsonConvert.DeserializeObject<List<ProductDto>>
                (File.ReadAllText(@"..\JsonDataAccess\Product.json"));
            if (products.Any(p => p.ProductName.ToLower().Replace(" ", string.Empty)
                     == request.ProductName.ToLower().Replace(" ", string.Empty)))
                throw new EntityAlreadyExistException("Product");

            var categoryName = JsonConvert.DeserializeObject<List<Category>>
                (File.ReadAllText(@"..\JsonDataAccess\Category.json"))
                .Where(c => c.Id == request.CategoryId).Select(c => c.CategoryName).First();
            var supplierName = JsonConvert.DeserializeObject<List<Supplier>>
                (File.ReadAllText(@"..\JsonDataAccess\Supplier.json"))
                .Where(s => s.Id == request.SupplierId).Select(c => c.SupplierName).First();
            var makerName = JsonConvert.DeserializeObject<List<Maker>>
             (File.ReadAllText(@"..\JsonDataAccess\Maker.json"))
             .Where(m => m.Id == request.MakerId).Select(c => c.MakerName).First();

            Random random = new Random();
            var randomNum  = random.Next(0, 100);
            var unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var id = Int64.Parse(unixTimestamp + "" + randomNum);

            products.Add(new ProductDto
            {
                Id = id,
                ProductName = request.ProductName,
                Description = request.Description,
                CategoryName = categoryName,
                SupplierName = supplierName,
                MakerName = makerName,
                Price = request.Price
            });

            File.WriteAllText(@"..\JsonDataAccess\Product.json", JsonConvert.SerializeObject(products));
        }
    }
}
