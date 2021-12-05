using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data;

namespace WillysWacky5.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _context.Products.Include(n => n.Ship).OrderBy(n => n.ProductName).ToListAsync();
            return View(allMovies);
        }
    }
}
