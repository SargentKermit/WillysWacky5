using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data;
using WillysWacky5.Data.Services;
using WillysWacky5.Data.Static;
using WillysWacky5.Models;

namespace WillysWacky5.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync(n => n.Ship);
            return View(allProducts);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAllAsync(n => n.Ship);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allProducts.Where(n => n.ProductName.Contains(searchString) || n.ProductDescription.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allProducts);
        }



        //GET: Products/Details/1
        [AllowAnonymous]
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




       
        //GET: Products/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            var response = new NewProductVM()
            {
                Id = productDetails.Id,
                ProductName = productDetails.ProductName,
                ProductDescription = productDetails.ProductDescription,
                ProductPrice = productDetails.ProductPrice,
                ProductImageURL = productDetails.ProductImageURL,
                ShipId = productDetails.ShipId,
                ProductCategory = productDetails.ProductCategory,
                DistributorIds = productDetails.Distributor_Products.Select(n => n.DistributorId).ToList(),
            };


            var productDropdownsData = await _service.GetNewProductDropdownsValues();
            ViewBag.Ships = new SelectList(productDropdownsData.Ships, "Id", "ShipAddress");
            ViewBag.Distributors = new SelectList(productDropdownsData.Distributors, "Id", "DistributorName");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM product)
        {
            if (id != product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewProductDropdownsValues();
                ViewBag.Ships = new SelectList(productDropdownsData.Ships, "Id", "ShipAddress");
                ViewBag.Distributors = new SelectList(productDropdownsData.Distributors, "Id", "DistributorName");
                return View(product);
            }

            await _service.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
