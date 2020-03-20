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
    public class JsonEditProductCommand : IEditProductCommand
    {
        public void Execute(ProductInsert request)
        {
            var products = JsonConvert.DeserializeObject<List<ProductDto>>
                (File.ReadAllText(@"..\JsonDataAccess\Product.json"));
            var product = products.Where(p => p.Id == request.Id).First();

            if (product == null)
                throw new EntityNotFoundException("Product");

            if (product.ProductName.ToLower().Replace(" ", string.Empty) 
                != request.ProductName.ToLower().Replace(" ", string.Empty))
            {
                if (products.Any(p => p.ProductName.ToLower().Replace(" ", string.Empty)
                            == request.ProductName.ToLower().Replace(" ", string.Empty)))
                    throw new EntityAlreadyExistException("Product");
            }

            var categoryName = JsonConvert.DeserializeObject<List<Category>>
               (File.ReadAllText(@"..\JsonDataAccess\Category.json"))
               .Where(c => c.Id == request.CategoryId).Select(c => c.CategoryName).First();
            var supplierName = JsonConvert.DeserializeObject<List<Supplier>>
                (File.ReadAllText(@"..\JsonDataAccess\Supplier.json"))
                .Where(s => s.Id == request.SupplierId).Select(c => c.SupplierName).First();
            var makerName = JsonConvert.DeserializeObject<List<Maker>>
             (File.ReadAllText(@"..\JsonDataAccess\Maker.json"))
             .Where(m => m.Id == request.MakerId).Select(c => c.MakerName).First();

            product.ProductName = request.ProductName;
            product.Description = request.Description;
            product.Price = request.Price;
            product.CategoryName = categoryName;
            product.SupplierName = supplierName;
            product.MakerName = makerName;

            File.WriteAllText(@"..\JsonDataAccess\Product.json", JsonConvert.SerializeObject(products));
        }
    }
}
