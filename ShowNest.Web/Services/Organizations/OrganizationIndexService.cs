using ShowNest.Web.Services.Organizations;
using ShowNest.Web.ViewModels.Organization;

namespace ShowNest.Web.Services.Organization
{
    public class OrganizationService
    {
        private readonly EventDetailService _eventDetailService;

        public OrganizationService(EventDetailService eventDetailService)
        {
            _eventDetailService = eventDetailService;
            OrganizationIndexViewModel = new OrganizationIndexViewModel(); 
        }

        public OrganizationIndexViewModel OrganizationIndexViewModel { get; set; }

        public (IEnumerable<IGrouping<string, EventDetail>>, IEnumerable<IGrouping<string, EventDetail>>) GetGroupedEvents()
        {
            return _eventDetailService.GetGroupedEvents();
        }
    }
}
