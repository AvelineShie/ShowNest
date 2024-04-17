namespace ShowNest.Web.ViewModels.Shared
{
    public class OrgsEventsInfroViewModel
    {
        public List<OrgsInfro> OrgsInfro { get; set; }
        public List <EventsInfro>EventsInfro { get; set; }
    }


    public class EventsInfro
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
    }

    public class OrgsInfro
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
    }

}


