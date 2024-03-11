using ShowNest.Web.Interfaces;
using ShowNest.Web.Services.General;
using ShowNest.Web.ViewModels.Home;

namespace ShowNest.Web.Services.Home
{
    public class HomeService
    {
        public HomeViewModel HomeViewModel { get; set; }

        private readonly CategoryTagService _categoryTagService;
        private readonly EventCardService _eventCardService;

        public HomeService(CategoryTagService categoryTagService, EventCardService eventCardService)
        {
            _categoryTagService = categoryTagService;
            _eventCardService = eventCardService;
            HomeViewModel = new HomeViewModel();
            HomeViewModel.HomeEventCards = new List<EventCardViewModel>();
        }

        public void GetHomeCards()
        {
            var cardsToAdd = _eventCardService.GetSixEventCards();
            foreach (var card in cardsToAdd)
            {
                HomeViewModel.HomeEventCards.Add(card);
            }
        }

    }


}
