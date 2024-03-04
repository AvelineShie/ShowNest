namespace ShowNest.Web.Services
{
	public class EventCardService
	{
		public IEnumerable<EventCardViewModel> SetEventCards()
		{
			IEnumerable<EventCardViewModel> EventCards = new List<EventCardViewModel>
			{
				new EventCardViewModel {
					EventName = "Build School Demo Test Activity",
					EventTime = "2024/04/24(三)",
					EventStatus = EventStatus.Selling
				},
				new EventCardViewModel {
					EventName = "BORN NAKED KINO LIVE IN HONG KONG",
					EventTime = "2024/04/20(六)",
					EventStatus = EventStatus.Selling
				},
				new EventCardViewModel {
					EventName = "Tattour HK 2024",
					EventTime = "2024/05/03(五)",
					EventStatus = EventStatus.ViewEvent
				},
				new EventCardViewModel {
					EventName = "Clockenflap Presents: Slowdive + special guest Ichiko Aoba",
					EventTime = "2024/03/14(四)",
					EventStatus = EventStatus.Selling
				},
				new EventCardViewModel {
					EventName = "DRUM TAO 30周年紀念-夢幻響2024台北站",
					EventTime = "2024/06/08(六)",
					EventStatus = EventStatus.ViewEvent
				},
				new EventCardViewModel {
					EventName = "黃玠-最好的朋友演唱會",
					EventTime = "2024/05/05(日)",
					EventStatus = EventStatus.Selling
				}
			};

			return EventCards;
		}
	}
}

