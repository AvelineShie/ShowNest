using ShowNest.Web.Services.Organizations;
using ShowNest.Web.ViewModels.Organization;

namespace ShowNest.Web.Services.Organization
{
    public class OrganizationIndexService
    {
        private readonly EventDetailService _eventDetailService;
        private readonly DatabaseContext _context;

        //public OrganizationIndexService(EventDetailService eventDetailService)
        //{
        //    _eventDetailService = eventDetailService;

        //}
        public OrganizationIndexService(DatabaseContext context)
        {
            _context = context;
        }

        
        public OrganizationIndexViewModel OrganizationIndexViewModel { get; set; }


        public (IEnumerable<IGrouping<string, EventDetail>>, IEnumerable<IGrouping<string, EventDetail>>) GetGroupedEvents(int organizationId)
        {
            var groupedEvents = _eventDetailService.GetGroupedEvents(organizationId);
            return (groupedEvents);
        }
        
        
        public OrganizationIndexViewModel GetOrganizationDetails(int organizationId) 
        {
            
            var organization = _context.Organizations.Find(organizationId); 

            if (organization == null)
            {
              return null;
            }

            return new OrganizationIndexViewModel
            {
                OrganizationId = organization.Id,
                OrganizationName = organization.Name,
                OrganizationImgUrl = organization.ImgUrl,  
                OrganizationDescription = organization.Description,
                OrganizationWeb = organization.OrganizationUrl,    
                OrganizationFBLink = organization.Fblink, 
                OrganizationEmail = organization.Email
            };
        }
    }

}
