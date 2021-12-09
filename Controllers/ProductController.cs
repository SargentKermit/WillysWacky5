using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data;
using WillysWacky5.Data.Services;
using WillysWacky5.Models;

namespace WillysWacky5.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync(n => n.Ship);
            return View(allProducts);
        }

        //GET: Products/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _service.GetProductByIdAsync(id);
            return View(productDetail);
        }
        //GET: Products/Create

        public async Task<IActionResult> Create()
        {
            var productDropdownsData = await _service.GetNewProductDropdownsValues();

            ViewBag.Ships = new SelectList(productDropdownsData.Ships, "Id", "ShipAddress");
            ViewBag.Distributors = new SelectList(productDropdownsData.Distributors, "Id", "DistributorName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product)
        {
            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewProductDropdownsValues();
                ViewBag.Ships = new SelectList(productDropdownsData.Ships, "Id", "ShipAddress");
                ViewBag.Distributors = new SelectList(productDropdownsData.Distributors, "Id", "DistributorName");
                return View(product);
            }

            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
