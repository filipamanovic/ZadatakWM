using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.ProductCommands;
using Application.Queries.ProductQueries;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetProductsCommand _getProducts;

        public ProductController(IGetProductsCommand getProducts)
        {
            _getProducts = getProducts;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] ProductQuery productQuery)
        {
            return View(_getProducts.Execute(productQuery));
        }
    }
}