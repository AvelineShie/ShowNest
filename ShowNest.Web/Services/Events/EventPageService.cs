
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace ShowNest.Web.Services.Events
{
    public class EventPageService
    {
        private readonly DatabaseContext _databaseContext;

        public EventPageService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public EventPageViewModel GetEventPageViewModel(string EventId)
        {
            var EventPage= _databaseContext.Events;
            return new EventPageViewModel {
               
            };
        }
    }
}
