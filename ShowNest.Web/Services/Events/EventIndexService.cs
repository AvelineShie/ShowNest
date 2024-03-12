using ShowNest.Web.ViewModels.Events;

namespace ShowNest.Web.Services.Events
{
    public class EventIndexService
    {
        public EventIndexViewModel EventIndexViewModel { get; }

        private readonly CategoryTagService _categoryTagService;
        private readonly EventCardService _eventCardService;

        public EventIndexService(CategoryTagService categoryTagService, EventCardService eventCardService)
        {
            _categoryTagService = categoryTagService;
            _eventCardService = eventCardService;
            EventIndexViewModel = new EventIndexViewModel
            {
                //EventIndexViewModel.EventCategoryTags = new List<CategoryTagsVeiwModel>();
                //EventCategoryTags = _categoryTagService.GetAllCategoryTags(),
                EventCategoryTags = _categoryTagService.GetCategoryTagsById(new List<int> { 1, 2, 3 }),
                //EventIndexViewModel.EventEventCards = new List<EventCardViewModel>();
                EventEventCards = _eventCardService.GetSixEventCards().ToList()
            };
        }

        public EventIndexViewModel GetEventIndexViewModel()
        {
            return EventIndexViewModel;
        }
    }
}
