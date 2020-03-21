using Application.Commands.CategoryCommands;
using Application.Dto.Category;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JsonCommands.CategoryCommands
{
    public class JsonCreateCategoryCommand : ICreateCategoryCommand
    {
        public void Execute(CategoryDto request)
        {
            var categories = JsonConvert.DeserializeObject<List<CategoryDto>>
                (File.ReadAllText(@"..\JsonDataAccess\Category.json"));
            categories.Add(new CategoryDto
            {
                Id = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
                CategoryName = request.CategoryName
            });

            File.WriteAllText(@"..\JsonDataAccess\Category.json", JsonConvert.SerializeObject(categories));
        }
    }
}
