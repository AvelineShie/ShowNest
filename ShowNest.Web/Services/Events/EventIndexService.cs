using ApplicationCore.Interfaces;
using ShowNest.Web.ViewModels.Events;

namespace ShowNest.Web.Services.Events
{
    public class EventIndexService
    {
        private readonly EventCardService _eventCardService;
        private readonly CategoryTagService _categoryTagService;

        public EventIndexService(EventCardService eventCardService, CategoryTagService categoryTagService)
        {
            _eventCardService = eventCardService;
            _categoryTagService = categoryTagService;
        }

        public async Task<EventIndexViewModel> GetEventIndexViewModel()
        {
            // 目前EventIndexViewModel只有卡片，預留增加其他東西的空間
            var result = new EventIndexViewModel();

            result.EventCategoryTags = await _categoryTagService.GetAllCategoryTags();  
            result.EventEventCards = await _eventCardService.GetEventIndexCardsViewModel();

            return result;
        }
    }
}
