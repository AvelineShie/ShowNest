using ShowNest.Web.Services.Organizations;
using ShowNest.Web.ViewModels.Organization;

namespace ShowNest.Web.Services.Organization
{
    public class OrganizationService
    {
        public OrganizationIndexViewModel OrganizationIndexViewModel { get; set; }
        public OrganizationDetailService OrganizationDetailService {  get;}

        private readonly EventDetailService _eventDetailService;

        public OrganizationService(EventDetailService eventDetailService)
        {
            _eventDetailService = eventDetailService;
            OrganizationIndexViewModel = new OrganizationIndexViewModel();
            OrganizationDetailService=new OrganizationDetailService();
        }
        public string GetGroupedEvents()
        {
            return "123";
        }




    }
}
