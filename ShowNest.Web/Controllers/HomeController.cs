using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.Interfaces;
using ShowNest.Web.Models;
using ShowNest.Web.Services;
using System.Diagnostics;

namespace ShowNest.Web.Controllers
{
    public class HomeController : Controller
    {
        // private readonly IEventCardService _eventCardService;
        // public HomeController(IEventCardService eventCardService)
        // {
        //     _eventCardService = eventCardService;
        // }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // var eventCardService = new EventCardService();
            //var eventCardsVM = eventCardService.SetEventCards();
            //return View(_eventCardService);

			return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
