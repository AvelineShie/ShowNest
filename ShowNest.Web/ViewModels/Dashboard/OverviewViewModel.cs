namespace ShowNest.Web.ViewModels.Dashboard
{
    public class OverviewViewModel
    {
        public string OrgName { get; set; }
        public List<EventsForOverview> OrgEvents { get; set; }

    }

    public class EventsForOverview
    {
        public int OrgEventId { get; set; }
        public string OrgEventName { get; set;}
    }
}
