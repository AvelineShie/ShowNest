using Microsoft.AspNetCore.Mvc;

namespace ShowNest.Web.Controllers
{
    public class PartialViewController : Controller
    {
        public IActionResult TicketTypeSelection()
        {
            return View();
        }

    }
}