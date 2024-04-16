using ApplicationCore.DTOs;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface ICreateEventService: IRepository<Event>,IRepository<EventAndTagMapping>
    {
        IEnumerable<Event> GetOrgEventsByOrgId(int orgId);
        public Event CreateEvent(CreateEventDto require);
        IEnumerable<Organization> GetOrgByUserId(int userId);

    }

}
