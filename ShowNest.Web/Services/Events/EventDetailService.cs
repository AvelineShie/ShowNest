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

        public (IEnumerable<IGrouping<string, EventDetail>>, IEnumerable<IGrouping<string, EventDetail>>) GetGroupedEvents(int organizationId)
        {
            // 使用 organizationId 來過濾正在進行中的活動清單
            var currentEvents = AllEvents
        .Where(e => e.OrganizationId == organizationId && e.EndTime >= DateTime.Now)
        .OrderByDescending(e => e.StartTime)
        .ToList();
            

            // 使用 organizationId 來過濾曾舉辦的活動清單
            var pastEvents = AllEvents
        .Where(e => e.OrganizationId == organizationId && e.EndTime < DateTime.Now)
        .OrderByDescending(e => e.StartTime)
        .ToList();

            // 以月份分組
           var groupedPastEvents = pastEvents.GroupBy(e => e.StartTime.ToString("yyyy/MM")).OrderByDescending(g => g.Key);
            var groupedCurrentEvents = (IEnumerable<IGrouping<string, EventDetail>>)currentEvents;
            return (groupedCurrentEvents, groupedPastEvents);

        }
    }

}
