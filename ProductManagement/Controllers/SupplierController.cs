using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.SupplierCommands;
using Application.Dto.Supplier;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ICreateSupplierCommand _createSupplier;

        public SupplierController(ICreateSupplierCommand createSupplier)
        {
            _createSupplier = createSupplier;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SupplierDto supplierDto)
        {
            _createSupplier.Execute(supplierDto);
            return RedirectToAction("Create", "Product");
        }
    }
}