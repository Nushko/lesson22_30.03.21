using lesson22_30._03._21.Models;
using Microsoft.EntityFrameworkCore;

namespace lesson22_30._03._21.Context
{

	public class ShopDbContext : DbContext
	{
		public ShopDbContext(DbContextOptions options) : base(options)
		{
		}
		protected ShopDbContext()
		{
		}
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories{ get; set; }

	}
}