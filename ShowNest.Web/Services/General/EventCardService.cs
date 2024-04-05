using ShowNest.Web.Interfaces;
using ShowNest.Web.ViewModels.General;

namespace ShowNest.Web.Services.General
{
    public class EventCardService
    {
        private readonly IEventCardQueryService _eventCardQueryService;

        public EventCardService(IEventCardQueryService eventCardQueryService)
        {
            _eventCardQueryService = eventCardQueryService;
        }

        public async Task<List<EventCardViewModel>> GetAllEventCardsViewModelByCategoryId(int categoryId)
        {
            var QueryResult = await _eventCardQueryService.GetAllCardsByCategoryId(categoryId);

            var result = new List<EventCardViewModel>();

            // 先到總查詢結果裡找categoryTag (按照順序的第一層)
            foreach (var categoryTag in QueryResult)
            {
                // categoryName都一樣，先在這邊設定好
                var categoryName = categoryTag.Name;

                // 再到categoryTag裡找eventAndTagMapping (按照順序的第二層)
                foreach (var eventAndTagMapping in categoryTag.EventAndTagMappings)
                {
                    List<string> GetEventStatusAndCssClassName(DateTime input)
                    {
                        if (DateTime.Now < input)
                        {
                            return new List<string> { "開賣中", "green-status" };
                        }
                        else
                        {
                            return new List<string> { "已結束", "black-status" };
                        }
                    }

                    result.Add(new EventCardViewModel
                    {
                        // 再到eventAndTagMapping裡找Event (按照順序的第三層)
                        EventId = eventAndTagMapping.Event.Id.ToString(),
                        EventName = eventAndTagMapping.Event.Name,
                        EventImgUrl = eventAndTagMapping.Event.EventImage,
                        CategoryName = categoryName,
                        EventTime = eventAndTagMapping.Event.StartTime,
                        EventStatus = GetEventStatusAndCssClassName(eventAndTagMapping.Event.StartTime)[0],
                        EventStatusCssClass = GetEventStatusAndCssClassName(eventAndTagMapping.Event.StartTime)[1],
                    });
                }
            }

            return result;
        }

        public async Task<List<EventCardViewModel>> GetNumbersOfCardsViewModelByCategoryId(int cardAmount, int categoryId)
        {
            var QueryResult = await _eventCardQueryService.GetNumbersOfCardsByCategoryId(cardAmount, categoryId);

            var result = new List<EventCardViewModel>();

            foreach (var categoryTag in QueryResult)
            {
                var categoryName = categoryTag.Name;

                foreach (var eventAndTagMapping in categoryTag.EventAndTagMappings.Take(cardAmount))
                {
                    List<string> GetEventStatusAndCssClassName(DateTime input)
                    {
                        if (DateTime.Now < input)
                        {
                            return new List<string> { "開賣中" , "green-status" };
                        }
                        else
                        {
                            return new List<string> { "已結束", "black-status" };
                        }
                    }

                    result.Add(new EventCardViewModel
                    {
                        EventId = eventAndTagMapping.Event.Id.ToString(),
                        EventName = eventAndTagMapping.Event.Name,
                        EventImgUrl = eventAndTagMapping.Event.EventImage,
                        CategoryName = categoryName,
                        EventTime = eventAndTagMapping.Event.StartTime,
                        EventStatus = GetEventStatusAndCssClassName(eventAndTagMapping.Event.StartTime)[0],
                        EventStatusCssClass = GetEventStatusAndCssClassName(eventAndTagMapping.Event.StartTime)[1],
                    });
                }
            }

            return result;
        }
    }
}
