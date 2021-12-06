using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillysWacky5.Data;
using WillysWacky5.Data.Services;

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
            var data = await _service.GetAll();
            return View(data);
        }
    }
}
