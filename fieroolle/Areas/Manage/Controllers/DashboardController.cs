using fieroolle.Models;
using Microsoft.AspNetCore.Mvc;

namespace fieroolle.Areas.Manage.Controllers
{
    [Area("manage")]
    public class DashboardController : Controller
    {
        private readonly FiorelloContext fiorelloContext;

        public DashboardController(FiorelloContext fiorelloContext)
        {
            this.fiorelloContext = fiorelloContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
