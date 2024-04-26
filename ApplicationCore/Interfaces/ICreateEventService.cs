using ApplicationCore.DTOs;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface ICreateEventService: IRepository<Event>,IRepository<EventAndTagMapping>
    {
        IEnumerable<Event> GetOrgEventsByOrgId(int orgId);
        IEnumerable<Organization> GetOrgByUserId(int userId);
        int CreateEvent(CreateEventDto require);
        int UpdateEvent(CreateEventDto require);
        CreateEventDto RenderEventData(int eventId);
    }

}
