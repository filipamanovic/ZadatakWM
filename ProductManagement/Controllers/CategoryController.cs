using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.CategoryCommands;
using Application.Dto.Category;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICreateCategoryCommand _createCategory;

        public CategoryController(ICreateCategoryCommand createCategory)
        {
            _createCategory = createCategory;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryDto categoryDto)
        {
            _createCategory.Execute(categoryDto);
            return RedirectToAction("Create", "Product");
        }
    }
}