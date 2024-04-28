using ApplicationCore.Entities;
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

        public async Task<List<EventCardViewModel>> GetAllEventCardsViewModelByCategoryId(int categoryId)
        {
            var queryResult = await _eventCardQueryService.GetAllCardsByCategoryId(categoryId);

            var result = new List<EventCardViewModel>();

            // 先到總查詢結果裡找categoryTag (按照順序的第一層)
            foreach (var categoryTag in queryResult)
            {
                // categoryName都一樣，先在這邊設定好
                var categoryName = categoryTag.Name;

                // 再到categoryTag裡找eventAndTagMapping (按照順序的第二層)
                foreach (var eventAndTagMapping in categoryTag.EventAndTagMappings)
                {
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
            var queryResult = await _eventCardQueryService.GetNumbersOfCardsByCategoryId(cardAmount, categoryId);

            var result = new List<EventCardViewModel>();

            foreach (var singleEvent in queryResult)
            {
                var categoryName = singleEvent.EventAndTagMappings.FirstOrDefault().CategoryTag.Name;

                result.Add(new EventCardViewModel
                {
                    EventId = singleEvent.Id.ToString(),
                    EventName = singleEvent.Name,
                    EventImgUrl = singleEvent.EventImage,
                    CategoryName = categoryName,
                    EventTime = singleEvent.StartTime,
                    EventStatus = GetEventStatusAndCssClassName(singleEvent.StartTime)[0],
                    EventStatusCssClass = GetEventStatusAndCssClassName(singleEvent.StartTime)[1],
                });

            }

            //foreach (var categoryTag in queryResult)
            //{
            //    var categoryName = categoryTag.Name;

            //    foreach (var eventAndTagMapping in categoryTag.EventAndTagMappings)
            //    {
            //        result.Add(new EventCardViewModel
            //        {
            //            EventId = eventAndTagMapping.Event.Id.ToString(),
            //            EventName = eventAndTagMapping.Event.Name,
            //            EventImgUrl = eventAndTagMapping.Event.EventImage,
            //            CategoryName = categoryName,
            //            EventTime = eventAndTagMapping.Event.StartTime,
            //            EventStatus = GetEventStatusAndCssClassName(eventAndTagMapping.Event.StartTime)[0],
            //            EventStatusCssClass = GetEventStatusAndCssClassName(eventAndTagMapping.Event.StartTime)[1],
            //        });
            //    }
            //}

            return result;
        }

        public async Task<List<EventCardViewModel>> GetEventIndexCardsViewModel()
        {
            var queryResult = await _eventCardQueryService.GetEventIndexCards();
            var result = new List<EventCardViewModel>();

            foreach (var eventIndexDto in queryResult)
            {
                result.Add(new EventCardViewModel
                {
                    EventId = eventIndexDto.EventId,
                    EventName = eventIndexDto.EventName,
                    EventImgUrl = eventIndexDto.EventImgUrl,
                    CategoryName = eventIndexDto.CategoryName,
                    EventTime = eventIndexDto.EventTime,
                    EventStatus = GetEventStatusAndCssClassName(eventIndexDto.EventTime)[0],
                    EventStatusCssClass = GetEventStatusAndCssClassName(eventIndexDto.EventTime)[1],
                });
            }

            return result;
        }


    }
}
