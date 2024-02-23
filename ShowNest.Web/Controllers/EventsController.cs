using Microsoft.AspNetCore.Mvc;

namespace ShowNest.Web.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EventPage()
        {
            return View();
        }
    }
}
