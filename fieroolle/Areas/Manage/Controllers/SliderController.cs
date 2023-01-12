using fieroolle.Helpers;
using fieroolle.Models;
using Microsoft.AspNetCore.Mvc;

namespace fieroolle.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SliderController : Controller
    {
        private readonly FiorelloContext fiorelloContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public SliderController(FiorelloContext fiorelloContext,IWebHostEnvironment webHostEnvironment)
        {
            this.fiorelloContext = fiorelloContext;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Slider> sliderList = fiorelloContext.sliders.ToList();
            return View(sliderList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
          

            slider.Image = FileManager.SaveFile(webHostEnvironment.WebRootPath, "Uploads/slider", slider.ImageFile);

            fiorelloContext.sliders.Add(slider);
            fiorelloContext.SaveChanges();

            return RedirectToAction("Index");
        }
		public IActionResult Update(int id)
		{
			Slider slider = fiorelloContext.sliders.Find(id);
			if (slider == null) return NotFound();

			return View(slider);
		}
		[HttpPost]
		public IActionResult Update(Slider slider)
		{

			Slider exslider = fiorelloContext.sliders.Find(slider.Id);
			if (exslider == null) return NotFound();
			if (slider.ImageFile != null)
			{
				if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg" && slider.ImageFile.ContentType != "jpg")
				{
					ModelState.AddModelError("ImageFile", "Ancaq png ve jpeg ola biler");
					return View();
				}
				if (slider.ImageFile.Length > 3145728)
				{
					ModelState.AddModelError("ImageFile", "Ancaq 3Mb ve ondan kicik sekiller elave olunmalidir");
					return View();
				}
				string name = FileManager.SaveFile(webHostEnvironment.WebRootPath, "Uploads/slider", slider.ImageFile);

				FileManager.DeleteFile(webHostEnvironment.WebRootPath, "Uploads/slider", exslider.Image);

				exslider.Image = name;

			}
			
			fiorelloContext.SaveChanges();

			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{

			Slider slider = fiorelloContext.sliders.Find(id);
			if (slider == null) return View("Error");
			fiorelloContext.sliders.Remove(slider);
			fiorelloContext.SaveChanges();
			FileManager.DeleteFile(webHostEnvironment.WebRootPath, "Uploads/slider", slider.Image);
			return RedirectToAction("Index");
		}
	}
}
