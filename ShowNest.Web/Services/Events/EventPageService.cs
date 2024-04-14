
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using ShowNest.Web.ViewModels.Events;
using ShowNest.Web.ViewModels.UserAccount;
using System.Collections.Generic;
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
                .Include(o=>o.Organization)
                .Include(ea => ea.EventAndTagMappings) 
                    .ThenInclude(ct => ct.CategoryTag)
                .Include(t => t.TicketTypes)
                    .ThenInclude(t => t.Tickets)
                    .ThenInclude(o=>o.Order)
                    .ThenInclude(u=>u.User)
                .AsNoTracking()
                .FirstOrDefault(e=>e.Id== EventId);
            if (EventPage == null)
            {
                return null;
            }
            var eventTicketTypes = EventPage.TicketTypes.Select(t => new EventTicketType
            {
                TicketTypeName = t.Name,
                TicketPrice = t.Price,
                TicketSalseBegin = t.StartSaleTime,
                TicketSalseEnd = t.EndSaleTime
            }).ToList();

            var eventCategoryTags = EventPage.EventAndTagMappings.Select(eatm => new CategoryTagsViewModel
            {
                Id= eatm.Id,
                CategoryName = eatm.CategoryTag.Name
            }).ToList();
            
            var AllParticipantPeoples = EventPage.TicketTypes
            .SelectMany(tt => tt.Tickets)
			.Where(t => t.Order != null)
			.GroupBy(t => t.Order.UserId) 
            .Select(group => group.First()) 
            .Select(t => new ParticipantPeople
            {
                Id = t.Order.User.Id,
                UserImage = t.Order.User.Image,
                UserNickname = t.Order.User.Nickname
            })
            .ToList();
            var countOfParticipants = AllParticipantPeoples.Count;
            var result = new EventPageViewModel
            {
                EventId = EventPage.Id,
                MainImage = EventPage.EventImage,
                MainOrganizer=EventPage.MainOrganizer,
                EventName = EventPage.Name,
                EventTime = EventPage.StartTime,
                EventLocationName = EventPage.LocationName,
                EventDescription = EventPage.Description,
                EventLocationAddress = EventPage.LocationAddress,
                Longitude = EventPage.Longitude,
                Latitude = EventPage.Latitude,
                EventRegistered = 1,//?
                EventCapacity = (int)EventPage.Capacity,
                OrganizationId = EventPage.OrganizationId,
                OrganizationName = EventPage.Organization.Name,
                EventTicketTypes = eventTicketTypes,
                EventCategoryTags = eventCategoryTags,
                AllParticipantPeoples= AllParticipantPeoples,
                countOfParticipants= countOfParticipants,
            };

            return result;
        }
    }
}
