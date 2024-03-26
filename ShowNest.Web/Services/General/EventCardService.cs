using ShowNest.Web.Interfaces;
using ShowNest.Web.ViewModels.General;

namespace ShowNest.Web.Services.General
{
    public class EventCardService
    {
        public List<EventCardViewModel> EventCards { get; }

        public EventCardService()
        {
            EventCards = new List<EventCardViewModel>
            {
                new EventCardViewModel {
                    EventName = "Build School Demo Test Activity",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=50",
                    CategoryNameZh = "講座",
                    EventTime = "2024/04/24(三)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "BORN NAKED KINO LIVE IN HONG KONG",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=51",
                    CategoryNameZh = "演唱會",
                    EventTime = "2024/04/20(六)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "Tattour HK 2024",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=52",
                    CategoryNameZh = "演唱會",
                    EventTime = "2024/05/03(五)",
                    EventStatus = EventStatus.ViewEvent
                },
                new EventCardViewModel {
                    EventName = "Clockenflap Presents: Slowdive + special guest Ichiko Aoba",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=53",
                    CategoryNameZh = "藝術",
                    EventTime = "2024/03/14(四)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "DRUM TAO 30周年紀念-夢幻響2024台北站",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=54",
                    CategoryNameZh = "音樂",
                    EventTime = "2024/06/08(六)",
                    EventStatus = EventStatus.ViewEvent
                },
                new EventCardViewModel {
                    EventName = "黃玠-最好的朋友演唱會",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=55",
                    CategoryNameZh = "演唱會",
                    EventTime = "2024/05/05(日)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "Build School Demo Test Activity 2",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=56",
                    CategoryNameZh = "講座",
                    EventTime = "2024/04/24(三)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "BORN NAKED KINO LIVE IN HONG KONG 2",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=57",
                    CategoryNameZh = "演唱會",
                    EventTime = "2024/04/20(六)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "Tattour HK 2024 2",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=58",
                    CategoryNameZh = "演唱會",
                    EventTime = "2024/05/03(五)",
                    EventStatus = EventStatus.ViewEvent
                },
                new EventCardViewModel {
                    EventName = "Clockenflap Presents: Slowdive + special guest Ichiko Aoba 2",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=59",
                    CategoryNameZh = "藝術",
                    EventTime = "2024/03/14(四)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "DRUM TAO 30周年紀念-夢幻響2024台北站 2",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=60",
                    CategoryNameZh = "音樂",
                    EventTime = "2024/06/08(六)",
                    EventStatus = EventStatus.ViewEvent
                },
                new EventCardViewModel {
                    EventName = "黃玠-最好的朋友演唱會 2",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=61",
                    CategoryNameZh = "演唱會",
                    EventTime = "2024/05/05(日)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "Build School Demo Test Activity 3",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=62",
                    CategoryNameZh = "講座",
                    EventTime = "2024/04/24(三)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "BORN NAKED KINO LIVE IN HONG KONG 3",
                    EventLink = "   /Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=63",
                    CategoryNameZh = "演唱會",
                    EventTime = "2024/04/20(六)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "Tattour HK 2024 3",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=64",
                    CategoryNameZh = "演唱會",
                    EventTime = "2024/05/03(五)",
                    EventStatus = EventStatus.ViewEvent
                },
                new EventCardViewModel {
                    EventName = "Clockenflap Presents: Slowdive + special guest Ichiko Aoba 3",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=65",
                    CategoryNameZh = "藝術",
                    EventTime = "2024/03/14(四)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "DRUM TAO 30周年紀念-夢幻響2024台北站 3",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=66",
                    CategoryNameZh = "音樂",
                    EventTime = "2024/06/08(六)",
                    EventStatus = EventStatus.ViewEvent
                },
                new EventCardViewModel {
                    EventName = "黃玠-最好的朋友演唱會 3",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=67",
                    CategoryNameZh = "演唱會",
                    EventTime = "2024/05/05(日)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "Build School Demo Test Activity 4",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=68",
                    CategoryNameZh = "講座",
                    EventTime = "2024/04/24(三)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "BORN NAKED KINO LIVE IN HONG KONG 4",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=69",
                    CategoryNameZh = "演唱會",
                    EventTime = "2024/04/20(六)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "Tattour HK 2024 4",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=70",
                    CategoryNameZh = "演唱會",
                    EventTime = "2024/05/03(五)",
                    EventStatus = EventStatus.ViewEvent
                },
                new EventCardViewModel {
                    EventName = "Clockenflap Presents: Slowdive + special guest Ichiko Aoba 4",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=71",
                    CategoryNameZh = "藝術",
                    EventTime = "2024/03/14(四)",
                    EventStatus = EventStatus.Selling
                },
                new EventCardViewModel {
                    EventName = "DRUM TAO 30周年紀念-夢幻響2024台北站 4",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=72",
                    CategoryNameZh = "音樂",
                    EventTime = "2024/06/08(六)",
                    EventStatus = EventStatus.ViewEvent
                },
                new EventCardViewModel {
                    EventName = "黃玠-最好的朋友演唱會 4",
                    EventLink = "/Events/EventPage",
                    EventImgUrl ="https://picsum.photos/300/200/?random=73",
                    CategoryNameZh = "演唱會",
                    EventTime = "2024/05/05(日)",
                    EventStatus = EventStatus.Selling
                }
            };
        }

        public EventCardViewModel GetEventCard(string name, string link, string imgUrl, string eventTime, EventStatus status)
        {
            return new EventCardViewModel
            {
                EventName = name,
                EventLink = link,
                EventImgUrl = imgUrl,
                EventTime = eventTime,
                EventStatus = status
            };
        }

        public IEnumerable<EventCardViewModel> GetAllEventCards()
        {
            return EventCards;
        }

        public IEnumerable<EventCardViewModel> GetSixEventCards()
        {
            return EventCards.Take(6);
        }

        public IEnumerable<EventCardViewModel> GetSixEventCards(int start)
        {
            return EventCards.Skip(start - 1).Take(6);
        }
    }
}
