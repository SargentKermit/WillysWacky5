using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data;
using WillysWacky5.Data.Services;

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
    }
}
