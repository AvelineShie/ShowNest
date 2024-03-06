using ShowNest.Web.ViewModels.Events;
using ShowNest.Web.ViewModels.UserAccount;

namespace ShowNest.Web.ViewModels.Dashboard
{
    public class CreateActivityViewModel
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public EventDetailViewModel EventName { get; set; }
    }

}



