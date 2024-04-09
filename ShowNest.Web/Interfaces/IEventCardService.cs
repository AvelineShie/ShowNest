using ShowNest.Web.ViewModels.General;

namespace ShowNest.Web.Interfaces
{
    public interface IEventCardService
    {
        IEnumerable<EventCardViewModel> EventCards { get;  }

        EventCardViewModel GetEventCard(string name, string link, string imgUrl, string eventTime);
    }
}
