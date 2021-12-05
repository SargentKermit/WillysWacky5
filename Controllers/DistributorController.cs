using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data;

namespace WillysWacky5.Controllers
{
    public class DistributorController : Controller
    {
        private readonly AppDbContext _context;

        public DistributorController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Distributors.ToList();
            return View(data);
        }
    }
}
