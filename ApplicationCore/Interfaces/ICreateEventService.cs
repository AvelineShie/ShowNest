using ApplicationCore.DTOs;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface ICreateEventService: IRepository<Event>,IRepository<EventAndTagMapping>
    {
        IEnumerable<Event> GetOrgEventsByOrgId(int orgId);
        public int CreateEvent(CreateEventDto require);
        //IEnumerable<Organization> GetOrgByUserId(int userId);
        public int UpdateEvent(CreateEventDto require);
        CreateEventDto RenderEventData(int eventId);
    }

}
