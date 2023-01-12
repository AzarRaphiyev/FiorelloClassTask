using System.ComponentModel.DataAnnotations.Schema;

namespace fieroolle.Models
{
	public class Product
	{
		public int Id { get; set; }
		public int CatagoryId { get; set; }
		
		public string Name { get; set; }
		public double Price { get; set; }
		public string Image { get; set; }

		[NotMapped]
		public IFormFile ImageFile { get; set; }
		public Catagory catagory { get; set; }
	}
}
