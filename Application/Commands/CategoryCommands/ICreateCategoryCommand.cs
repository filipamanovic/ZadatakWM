using Application.Dto.Category;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.CategoryCommands
{
    public interface ICreateCategoryCommand : ICommand<CategoryDto>
    {
    }
}
