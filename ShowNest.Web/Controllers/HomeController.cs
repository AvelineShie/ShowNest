using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.Interfaces;
using ShowNest.Web.Models;
using ShowNest.Web.Services.General;
using ShowNest.Web.Services.Home;
using System.Diagnostics;

namespace ShowNest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _homeService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(HomeService homeService, ILogger<HomeController> logger)
        {
            _homeService = homeService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var homeViewModel = _homeService.HomeViewModel;
            _homeService.GetHomeCarouselImg(homeViewModel.HomeCarousels);
            _homeService.GetHomeCards(homeViewModel.HomeEventCards);

            int cardsPerPage = 6;

            return View(homeViewModel);
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
