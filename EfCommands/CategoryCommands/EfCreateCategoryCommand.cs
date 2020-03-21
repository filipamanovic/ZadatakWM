using Application.Commands.CategoryCommands;
using Application.Dto.Category;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.CategoryCommands
{
    public class EfCreateCategoryCommand : BaseContext, ICreateCategoryCommand
    {
        public EfCreateCategoryCommand(Context context) : base(context)
        {
        }

        public void Execute(CategoryDto request)
        {
            _context.Categories.Add(new Category
            {
                CategoryName = request.CategoryName
            });

            _context.SaveChanges();
        }
    }
}
