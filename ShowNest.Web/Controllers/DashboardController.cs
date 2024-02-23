using Microsoft.AspNetCore.Mvc;

namespace ShowNest.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Organization()
        {
            return View();
        }

        public IActionResult Events()
        {
            return View("ActivitiesList");
        }
    }
}
