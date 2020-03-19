using System;
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
        private readonly IGetProductCommand _getProduct;
        private readonly IEditProductCommand _editProduct;

        public ProductController(IGetProductsCommand getProducts, IGetProductInsertData getProductInsertData, 
            ICreateProductCommand createProduct, IGetProductCommand getProduct, IEditProductCommand editProduct)
        {
            _getProducts = getProducts;
            _getProductInsertData = getProductInsertData;
            _createProduct = createProduct;
            _getProduct = getProduct;
            _editProduct = editProduct;
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
                catch (Exception e)
                {
                    TempData["Msg"] = e.Message;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ProductInsertData = _getProductInsertData.Execute();
            return View(productInsert);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var product = _getProduct.Execute(Id);
                ViewBag.ProductInsertData = _getProductInsertData.Execute();
                return View(product);
            }
            catch(EntityNotFoundException e)
            {
                TempData["Msg"] = e.Message;
                return RedirectToAction("index");
            }
            catch (Exception e) 
            {
                TempData["Msg"] = e.Message;
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        public IActionResult Edit(int Id, ProductInsert productInsert)
        {
            productInsert.Id = Id;

            if (ModelState.IsValid)
            {
                try
                {
                    _editProduct.Execute(productInsert);
                    TempData["Msg"] = "Succesfully edited product";
                    return RedirectToAction("Index");
                }
                catch(EntityNotFoundException e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                    ViewBag.ProductInsertData = _getProductInsertData.Execute();
                    return View(productInsert);
                }
                catch(EntityAlreadyExistException e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                    ViewBag.ProductInsertData = _getProductInsertData.Execute();
                    return View(productInsert);
                }
                catch (Exception e)
                {
                    TempData["Msg"] = e.Message;
                    return RedirectToAction("Index");
                }
            }
            return View(productInsert);
        }
    }
}