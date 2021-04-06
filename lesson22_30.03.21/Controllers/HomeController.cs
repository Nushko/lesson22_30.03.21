using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using lesson22_30._03._21.Models;
using lesson22_30._03._21.Context;

namespace lesson22_30._03._21.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly ShopDbContext _shopDbContext;

		public HomeController(ILogger<HomeController> logger, ShopDbContext shopDbContext)
        {
            _logger = logger;
			_shopDbContext = shopDbContext;
		}

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
