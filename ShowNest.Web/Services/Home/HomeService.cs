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
        }

        public async Task<HomeViewModel> GetHomeViewModel()
        {
            var homeViewModel = new HomeViewModel();

            homeViewModel.HomeCarousels = _homeCarouselService.GetCarouselViewModel();
            homeViewModel.MainSectionTag1Cards = await _eventCardService.GetNumbersOfCardsViewModelByCategoryId(6, 10);
            homeViewModel.MainSectionTag2Cards = await _eventCardService.GetNumbersOfCardsViewModelByCategoryId(6, 3);
            homeViewModel.MainSectionTag3Cards = await _eventCardService.GetNumbersOfCardsViewModelByCategoryId(6, 2);
            homeViewModel.SubSectionCards = await _eventCardService.GetNumbersOfCardsViewModelByCategoryId(9, 4);

            return homeViewModel;
        }

    }


}
