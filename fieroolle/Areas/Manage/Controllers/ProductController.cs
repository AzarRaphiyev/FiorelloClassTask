using fieroolle.Helpers;
using fieroolle.Models;
using Microsoft.AspNetCore.Mvc;

namespace fieroolle.Areas.Manage.Controllers
{
	[Area("manage")]
	public class ProductController : Controller
	{
		private readonly FiorelloContext fiorelloContext;
		private readonly IWebHostEnvironment webHostEnvironment;

		public ProductController(FiorelloContext fiorelloContext,IWebHostEnvironment webHostEnvironment)
		{
			this.fiorelloContext = fiorelloContext;
			this.webHostEnvironment = webHostEnvironment;
		}
		public IActionResult Index()
		{
			List<Product> products = fiorelloContext.products.ToList();
			return View(products);
		}
		[HttpGet]
		public IActionResult Create()
		{
			if (!ModelState.IsValid) return View();

			return View();
		}
		[HttpPost]
		public  IActionResult Create(Product product)
		{
            if (product.ImageFile.ContentType != "image/png" && product.ImageFile.ContentType != "image/jpeg" )
            {
                ModelState.AddModelError("ImageFile", "Ancaq png ve jpeg ola biler");
                return View();
            }
            if (product.ImageFile.Length > 3145728)
            {
                ModelState.AddModelError("ImageFile", "Ancaq 3Mb ve ondan kicik sekiller elave olunmalidir");
                return View();
            }
			product.Image = FileManager.SaveFile(webHostEnvironment.WebRootPath, "Uploads/Books",product.ImageFile);
			fiorelloContext.products.Add(product);
			fiorelloContext.SaveChanges();
			return RedirectToAction(nameof(Index));
        }
		[HttpGet]
		public IActionResult Update(int id)
		{
			Product product = fiorelloContext.products.Find(id);
			if (product == null) return NotFound();
			return View(product);

		}

	}
}
