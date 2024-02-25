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
            if (viewType == "RegistrationList")
            {
                return View("RegistrationList");
            }

            if (viewType == "SetActivity")
            {
                return View("SetActivity");
            }

            if (viewType == "SetTicket")
            {
                return View("SetTicket");
            }

            return BadRequest("Invalid view type.");
        }
    }
}
