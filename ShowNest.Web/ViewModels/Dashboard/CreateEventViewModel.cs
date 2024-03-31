using ShowNest.Web.ViewModels.Events;
using ShowNest.Web.ViewModels.UserAccount;

namespace ShowNest.Web.ViewModels.Dashboard
{
    public class CreateEventViewModel
    {
        [Required]
        public List <OrganizationList> OrgName { get; set; }
        public List <EventList> EventName { get; set; }
    }

    public class EventList
    {

    }

    public class OrganizationList
    {
    }
}



