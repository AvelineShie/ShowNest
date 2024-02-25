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

        public IActionResult Events(string viewType)
        {
            if (viewType == "ActivitiesList")
            {
                return View("ActivitiesList");
            }
            else if (viewType == "RegistrationList")
            {
                return View("RegistrationList");
            }

            return BadRequest("Invalid view type.");
        }
    }
}
