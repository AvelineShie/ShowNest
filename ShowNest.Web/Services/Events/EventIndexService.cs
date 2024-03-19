using ShowNest.Web.ViewModels.Events;

namespace ShowNest.Web.Services.Events
{
    public class EventIndexService
    {
        private readonly CategoryTagService _categoryTagService;
        private readonly EventCardService _eventCardService;

        public EventIndexService(CategoryTagService categoryTagService, EventCardService eventCardService)
        {
            _categoryTagService = categoryTagService;
            _eventCardService = eventCardService;
        }

        public EventIndexViewModel GetEventIndexViewModel()
        {
            return new EventIndexViewModel
            {
                EventCategoryTags = _categoryTagService.GetAllCategoryTags(),
                EventEventCards = _eventCardService.GetSixEventCards().ToList()
            };
        }
    }
}
