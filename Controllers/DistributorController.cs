using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data;
using WillysWacky5.Data.Services;
using WillysWacky5.Models;

namespace WillysWacky5.Controllers
{
    public class DistributorController : Controller
    {
        private readonly IDistributorService _service;

        public DistributorController(IDistributorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get: Distributors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("DistributorLogoURL,DistributorName,DistributorAddress")]Distributor distributor)
        {
            if (!ModelState.IsValid)
            {
                return View(distributor);
            }
            await _service.AddAsync(distributor);
            return RedirectToAction(nameof(Index));
        }

        //GET: Distributors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var distributorDetails = await _service.GetByIdAsync(id);

            if (distributorDetails == null) return View("Empty");
            return View(distributorDetails);
        }
        
    }
}
