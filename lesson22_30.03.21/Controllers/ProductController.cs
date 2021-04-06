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
using Microsoft.EntityFrameworkCore;
using lesson22_30._03._21.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lesson22_30._03._21.Controllers
{
	public class ProductController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ShopDbContext _shopDbContext;

		public ProductController(ILogger<HomeController> logger, ShopDbContext shopDbContext)
		{
			_shopDbContext = shopDbContext;
			_logger = logger;

		}
		[HttpGet]
		public async Task<IActionResult> Index(string category)
		{
			List<Product> lst = new List<Product>();
			if (category == null)
			{
				lst = await _shopDbContext.Products.ToListAsync();
			}
			else
			{
				lst = await _shopDbContext.Products.Where(p => p.Category.Name.Equals(category)).ToListAsync();
			}
			return View(lst);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var rez = await _shopDbContext.Categories.ToListAsync();

			return View(new ProductViewModel()
			{
				Categories = rez.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() }).ToList()
			});
		}
		[HttpPost]
		public async Task<IActionResult> Create(ProductViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			_shopDbContext.Products.Add(new Product()
			{
				Name = model.Name,
				Price = model.Price,
				CategoryId = model.CategoryId
			});

			await _shopDbContext.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (id <= 0)
			{
				return RedirectToAction("Index");
			}

			var rez = await _shopDbContext.Products.FindAsync(id);

			if (rez == null)
			{
				return RedirectToAction("Index");
			}
			return View(new ProductViewModel()
			{
				Id = rez.Id,
				Name = rez.Name,
				Price = rez.Price,
				Categories = await _shopDbContext.Categories.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() }).ToListAsync()
			});
		}
		[HttpPost]
		public async Task<IActionResult> Edit(CategoryViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var rez = _shopDbContext.Categories.Find(model.Id);
			if (rez == null)
			{
				return RedirectToAction("Index");
			}

			rez.Name = model.Name;
			await _shopDbContext.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			if (id <= 0)
			{
				return RedirectToAction("Index");
			}
			var rez = _shopDbContext.Products.Find(id);
			if (rez == null)
			{
				return RedirectToAction("Index");
			}
			_shopDbContext.Products.Remove(rez);
			await _shopDbContext.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
