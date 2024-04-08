using ApplicationCore.Interfaces;
using ShowNest.Web.ViewModels.Events;

namespace ShowNest.Web.Services.Events
{
    public class EventIndexService
    {
        private readonly EventCardService _eventCardService;
        private readonly CategoryTagService _categoryTagService;
        private readonly EventsIndexCardsAPIServiceByEf _eventsIndexCardsAPIServiceByEf;

        public EventIndexService(EventCardService eventCardService, CategoryTagService categoryTagService, EventsIndexCardsAPIServiceByEf eventsIndexCardsAPIServiceByEf)
        {
            _eventCardService = eventCardService;
            _categoryTagService = categoryTagService;
            _eventsIndexCardsAPIServiceByEf = eventsIndexCardsAPIServiceByEf;
        }

        public async Task<EventIndexViewModel> GetEventIndexViewModel()
        {
            // 目前EventIndexViewModel只有卡片，預留增加其他東西的空間
            var result = new EventIndexViewModel();

            result.EventCategoryTags = await _categoryTagService.GetAllCategoryTags();  
            result.EventEventCards = await _eventCardService.GetEventIndexCardsViewModel();

            return result;
        }

        public async Task<EventIndexViewModel> GetEventIndexCategoryTags()
        {
            var result = new EventIndexViewModel
            {
                // 卡片用fetch獲取的話，EventIndexViewModel剩下category tag
                EventCategoryTags = await _categoryTagService.GetAllCategoryTags()
            };

            return result;
        }


    }
}
