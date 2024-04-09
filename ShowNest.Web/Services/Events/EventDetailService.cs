using ShowNest.Web.ViewModels.Organization;

namespace ShowNest.Web.Services.Events
{
    public class EventDetailService
    {
        private readonly DatabaseContext _context;

        public EventDetailService(DatabaseContext context)
        {
            _context = context;
        }


        public List<EventDetail> AllEvents => _context.Events.Select(e => new EventDetail
        {
            Id = e.Id,
            EventImage = e.EventImage,
            EventName = e.Name,
            StartTime = e.StartTime,
            EndTime = e.EndTime,
            EventIntroduction = e.Introduction,
        })
         .ToList();
        public List<EventDetail> GetCurrentEvents(int organizationId)
        {

            var CurrentEvents = AllEvents
        .Where(e => e.OrganizationId == organizationId && e.EndTime >= DateTime.Now)
        .OrderByDescending(e => e.StartTime)
        .ToList();
            return (CurrentEvents);
        }
        public IEnumerable<IGrouping<string, EventDetail>> GetGroupedPastEvents(int organizationId)
        {
            var pastEvents = AllEvents
        .Where(e => e.OrganizationId == organizationId && e.EndTime < DateTime.Now)
        .OrderByDescending(e => e.StartTime)
        .ToList();
            var groupedPastEvents = pastEvents.GroupBy(e => e.StartTime.ToString("yyyy/MM")).OrderByDescending(g => g.Key);

            return (groupedPastEvents);
        }


    }

}
