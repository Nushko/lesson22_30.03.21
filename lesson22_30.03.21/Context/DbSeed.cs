using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lesson22_30._03._21.Models;

namespace lesson22_30._03._21.Context
{
	public class DbSeed
	{
		public static async Task Seed(ShopDbContext context)
		{
			if (!context.Categories.Any())
			{
				context.Categories.AddRange(new List<Category>
				{
					new Category { Name = "Фрукты" },
					new Category { Name = "Зелень" },
					new Category { Name = "Овощи" }
				});
				await context.SaveChangesAsync();
			}
			if (!context.Products.Any())
			{
				context.Products.Add(new Product()
				{
					Name = "Банан",
					Price = 4,
					CategoryId = context.Categories.Where(p=>p.Name=="Фрукты").FirstOrDefault().Id
					// CategoryId = context.Categories.Find("Фрукты").Id
				});
				context.Products.Add(new Product()
				{
					Name = "Картошка",
					Price = 6,
					CategoryId = context.Categories.Where(p=>p.Name=="Овощи").FirstOrDefault().Id

					// CategoryId = context.Categories.Find("Овощи").Id
				});
				context.Products.Add(new Product()
				{
					Name = "Петрушка",
					Price = 1,
					CategoryId = context.Categories.Where(p=>p.Name=="Зелень").FirstOrDefault().Id
					// CategoryId = context.Categories.Find("Зелень").Id
				});
				await context.SaveChangesAsync();
			}
		}
	}
}