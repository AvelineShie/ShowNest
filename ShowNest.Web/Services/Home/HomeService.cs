using ShowNest.Web.Interfaces;
using ShowNest.Web.Services.General;
using ShowNest.Web.ViewModels.Home;

namespace ShowNest.Web.Services.Home
{
    public class HomeService
    {
        public HomeViewModel HomeViewModel { get; set; }

        private readonly HomeCarouselService _homeCarouselService;
        private readonly EventCardService _eventCardService;

        public HomeService(HomeCarouselService homeCarouselService, EventCardService eventCardService)
        {
            _homeCarouselService = homeCarouselService;
            _eventCardService = eventCardService;
            HomeViewModel = new HomeViewModel();
            HomeViewModel.HomeCarousels = new List<HomeCarouselViewModel>();
            HomeViewModel.HomeEventCards = new List<EventCardViewModel>();
        }

        public List<HomeCarouselViewModel> GetHomeCarouselImg(List<HomeCarouselViewModel> input)
        {
            var imgsToAdd = _homeCarouselService.Carousels;
            foreach (var img in imgsToAdd)
            {
                input.Add(img);
            }

            return input;
        }

        public List<EventCardViewModel> GetHomeCards(List<EventCardViewModel> input)
        {
            var cardsToAdd = _eventCardService.GetAllEventCards();
            foreach (var card in cardsToAdd)
            {
                input.Add(card);
            }

            return input;
        }

    }


}
