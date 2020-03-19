﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.ProductCommands;
using Application.Dto.Product;
using Application.Exceptions;
using Application.Queries.ProductQueries;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGetProductsCommand _getProducts;
        private readonly IGetProductInsertData _getProductInsertData;
        private readonly ICreateProductCommand _createProduct;

        public ProductController(IGetProductsCommand getProducts, 
            IGetProductInsertData getProductInsertData, ICreateProductCommand createProduct)
        {
            _getProducts = getProducts;
            _getProductInsertData = getProductInsertData;
            _createProduct = createProduct;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] ProductQuery productQuery)
        {
            return View(_getProducts.Execute(productQuery));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ProductInsertData = _getProductInsertData.Execute();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductInsert productInsert)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _createProduct.Execute(productInsert);
                    TempData["Msg"] = "Succesfully created product";
                    return RedirectToAction("Index");
                }
                catch (EntityAlreadyExistException e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                    ViewBag.ProductInsertData = _getProductInsertData.Execute();
                    return View(productInsert);
                }
            }
            ViewBag.ProductInsertData = _getProductInsertData.Execute();
            return View(productInsert);
        }
    }
}