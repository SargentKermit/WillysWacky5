using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data;

namespace WillysWacky5.Controllers
{
    public class ShipController : Controller
    {
        private readonly AppDbContext _context;

        public ShipController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allShips = await _context.Ships.ToListAsync();
            return View(allShips);
        }
    }
}
