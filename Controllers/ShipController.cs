using Microsoft.AspNetCore.Mvc;
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
    public class ShipController : Controller
    {
        private readonly IShipService _service;

        public ShipController(IShipService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allShips = await _service.GetAllAsync();
            return View(allShips);
        }

        //Get: Ship/Create
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ShipMapLocationURL,ShipState,ShipAddress")]Ship ship)
        {
            if (!ModelState.IsValid) return View(ship);
            await _service.AddAsync(ship);
            return RedirectToAction(nameof(Index));
        }
    }
}
