
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using ShowNest.Web.ViewModels.UserAccount;
using System.ComponentModel;

namespace ShowNest.Web.Services.Events
{
    public class EventPageService
    {
        private readonly DatabaseContext _databaseContext;

        public EventPageService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public EventPageViewModel GetEventPageViewModel(int EventId)
        {
            var test = _databaseContext.Events.FirstOrDefault(x =>x.Id == EventId);
            var EventPage= _databaseContext.Events
                .Include(e=>e.Organization)
                .Include(t => t.TicketTypes)
                    .ThenInclude(t => t.Tickets)
                .AsNoTracking()
                .FirstOrDefault(e=>e.Id== EventId);
            if (EventPage == null)
            {
                return null;
            }

            var result = new EventPageViewModel {
               EventId= EventPage.Id,
                MainImage= EventPage.EventImage,
                EventName=EventPage.Name,
                EventTime= EventPage.StartTime,
                EventLocationName=EventPage.LocationName,
                EventDescription=EventPage.Description,
                EventLocationAddress=EventPage.LocationAddress,
                Longitude=EventPage.Longitude,
                Latitude=EventPage.Latitude,
                EventRegistered=1,//?
                EventCapacity = (int)EventPage.Capacity,
                OrganizationId= EventPage.OrganizationId,
                OrganizationName=EventPage.Organization.Name
            };

            return result;
        }
    }
}
