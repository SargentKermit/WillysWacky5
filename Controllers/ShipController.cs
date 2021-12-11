using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class ShipController : Controller
    {
        private readonly IShipService _service;

        public ShipController(IShipService service)
        {
            _service = service;
        }
        [AllowAnonymous]
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

        //Get: Ship/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var shipDetails = await _service.GetByIdAsync(id);
            if (shipDetails == null) return View("NotFound");
            return View(shipDetails);
        }

        //Get: Ship/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var shipDetails = await _service.GetByIdAsync(id);
            if (shipDetails == null) return View("NotFound");
            return View(shipDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ShipMapLocationURL,ShipState,ShipAddress")] Ship ship)
        {
            if (!ModelState.IsValid) return View(ship);
            await _service.UpdateAsync(id, ship);
            return RedirectToAction(nameof(Index));
        }

        //Get: Ship/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var shipDetails = await _service.GetByIdAsync(id);
            if (shipDetails == null) return View("NotFound");
            return View(shipDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var shipDetails = await _service.GetByIdAsync(id);
            if (shipDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
