using Microsoft.EntityFrameworkCore;

namespace fieroolle.Models
{
	public class FiorelloContext:DbContext
	{
		public FiorelloContext(DbContextOptions<FiorelloContext> options):base(options) { }
		public DbSet<Slider> sliders { get; set; }
		public DbSet<Catagory> catagories { get; set; }
		public DbSet<Product> products{ get; set; }
	}
}
