using Application.Commands.SupplierCommands;
using Application.Dto.Supplier;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JsonCommands.SupplierCommands
{
    public class JsonCreateSupplierCommand : ICreateSupplierCommand
    {
        public void Execute(SupplierDto request)
        {
            var suppliers = JsonConvert.DeserializeObject<List<SupplierDto>>
                (File.ReadAllText(@"..\JsonDataAccess\Supplier.json"));
            suppliers.Add(new SupplierDto
            {
                Id = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
                SupplierName = request.SupplierName
            });

            File.WriteAllText(@"..\JsonDataAccess\Supplier.json", JsonConvert.SerializeObject(suppliers));
        }
    }
}
