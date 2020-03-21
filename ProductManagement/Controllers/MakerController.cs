using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.MakerCommands;
using Application.Dto.Maker;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Controllers
{
    public class MakerController : Controller
    {
        private readonly ICreateMakerCommand _createMaker;

        public MakerController(ICreateMakerCommand createMaker)
        {
            _createMaker = createMaker;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MakerDto makerDto)
        {
            _createMaker.Execute(makerDto);
            return RedirectToAction("Create", "Product");
        }
    }
}