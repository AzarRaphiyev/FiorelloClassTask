using fieroolle.Models;
using fieroolle.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace fieroolle.Controllers
{
	public class HomeController : Controller
	{
		private readonly FiorelloContext fiorelloContext;

		public HomeController(FiorelloContext fiorelloContext)
		{
			this.fiorelloContext = fiorelloContext;
		}
		public IActionResult Index()
		{
			HomeViewModels homeViewModels = new HomeViewModels
			{
				sliders = fiorelloContext.sliders.ToList(),
			};
			return View(homeViewModels);
		}
	
	}
}