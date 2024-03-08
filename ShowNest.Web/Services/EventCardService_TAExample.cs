using ShowNest.Web.Interfaces;
using ShowNest.Web.ViewModels.General;
using System.Linq.Expressions;

namespace ShowNest.Web.Services
{
    public class EventCardService_TAExample : IEventCardService
    {
        public IEnumerable<EventCardViewModel> EventCards { get; }

        public EventCardService_TAExample()
        {
            EventCards = new List<EventCardViewModel>
            {
                new EventCardViewModel {
                    EventName = "Build School Demo Test Activity",
                    EventLink = "./Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=50",
                    EventTime = "2024/04/24(三)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "BORN NAKED KINO LIVE IN HONG KONG",
                    EventLink = "./Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=51",
                    EventTime = "2024/04/20(六)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "Tattour HK 2024",
                    EventLink = "./Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=52",
                    EventTime = "2024/05/03(五)",
                    EventStatus = EventStatus.ViewEvent
                },
                new EventCardViewModel {
                    EventName = "Clockenflap Presents: Slowdive + special guest Ichiko Aoba",
                    EventLink = "./Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=53",
                    EventTime = "2024/03/14(四)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "DRUM TAO 30周年紀念-夢幻響2024台北站",
                    EventLink = "./Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=54",
                    EventTime = "2024/06/08(六)",
                    EventStatus = EventStatus.ViewEvent
                },
                new EventCardViewModel {
                    EventName = "黃玠-最好的朋友演唱會",
                    EventLink = "./Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=55",
                    EventTime = "2024/05/05(日)",
                    EventStatus = EventStatus.Selling
                }
            };

        }


        public IEnumerable<EventCardViewModel> GetHomePageEvents()
        {
            //從Service取得之後，組ViewModel
            //return EventCards.Select(x => GetEventCard(x.EventName, x.EventImgUrl,new DateTime(),x.EventLink, EventStatus.ViewEvent));
            //return EventCards.Select(x => new EventCardViewModel
            //{
            //     EventStatus = x.EventStatus,
            //      EventName = x.EventName,
            //});

            foreach (var item in EventCards)
            {

                yield return new EventCardViewModel { };
            }
        }
        public EventCardViewModel GetProductById(int id)
        {
            //從資料庫拿
            //連資料庫
            //離開資料庫
            return new EventCardViewModel { };
        }

        public EventCardViewModel GetEventCard(string name, string imgUrl, DateTime eventTime, string link, EventStatus status)
        {
            return new EventCardViewModel
            {
                EventName = name,
                EventLink = link,
                EventImgUrl = imgUrl,
                EventStatus = status,
                EventTime = eventTime.ToString("yyyy/MM/dd(ddd)")
            };
        }

        public EventCardViewModel GetEventCard(string name, string link, string imgUrl, DateTime eventTime, EventStatus status)
        {
            throw new NotImplementedException();
        }

        public EventCardViewModel GetEventCard(string name, string link, string imgUrl, string eventTime, EventStatus status)
        {
            throw new NotImplementedException();
        }
    }

    public class HomePageEvent
    {
        public string MyProperty { get; set; }
        public string MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }

        public IEnumerable<EventCardViewModel> EventCards { get; set; }
    }
}

