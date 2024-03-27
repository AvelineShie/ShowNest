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

        public (IEnumerable<IGrouping<string, EventDetail>>, IEnumerable<IGrouping<string, EventDetail>>) GetGroupedEvents()
        {
            // 取得正在進行中的活動清單
            var currentEvents = AllEvents
                .Where(e => e.EndTime >= DateTime.Now)
                .OrderByDescending(e => e.StartTime)
                .ToList();

            // 取得曾舉辦的活動清單
            var pastEvents = AllEvents
            .Where(e => e.EndTime < DateTime.Now)
            .OrderByDescending(e => e.StartTime)
            .ToList();

            // 以月份分組
           var groupedPastEvents = pastEvents.GroupBy(e => e.StartTime.ToString("yyyy/MM")).OrderByDescending(g => g.Key);
            var groupedCurrentEvents = currentEvents.GroupBy(e => e.StartTime.ToString("yyyy/MM")).OrderByDescending(g => g.Key);
            Console.WriteLine(groupedPastEvents);
            Console.WriteLine(groupedCurrentEvents);
            return (groupedPastEvents, groupedCurrentEvents);

        }
    }

}
