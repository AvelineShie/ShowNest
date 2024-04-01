using ShowNest.Web.ViewModels.Dashboard;

namespace ShowNest.Web.Services.Dashboard
{
    public class OverviewService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OverviewService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public OverviewViewModel GetOverviewViewModel(int orgId)
        {
            var org = _organizationRepository.GetOrgById(orgId);
            var orgEvents = _organizationRepository.GetOrgEventsByOrgId(orgId);

            var result = new OverviewViewModel
            {
                OrgId = orgId,
                OrgName = org.Name,
                OrgEvents = new List<EventsForOverview>()
            };

            foreach (var orgEvent in orgEvents)
            {
                var eventToAdd = new EventsForOverview
                {
                    OrgEventId = orgEvent.Id,
                    OrgEventName = orgEvent.Name,
                };
                result.OrgEvents.Add(eventToAdd);
            }

            return result;
        }
    }
}
