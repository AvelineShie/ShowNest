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
                OrgWebUrl = org.OrganizationUrl,
                OrgDescription = org.Description,
                OrgFbUrl = org.Fblink,
                OrgIgUrl = org.Igaccount,
                OrgEmail = org.Email,
                OrgContactName = org.ContactName,
                OrgContactCellphone = org.ContactMobile,
                OrgContactTelepohone = org.ContactTelephone,
                OrgEvents = new List<EventsForOverview>()
            };

            string GetEventStatus(byte input)
            {
                if (input == 0)
                {
                    return "未發布";
                }
                else
                {
                    return "已發布";
                }
            }

            bool isOnGoing(DateTime input){
                if (DateTime.Now < input){
                    return true;
                }else{
                    return false;
                }
            }

            foreach (var orgEvent in orgEvents)
            {
                var eventToAdd = new EventsForOverview
                {
                    OrgEventId = orgEvent.Id,
                    OrgEventName = orgEvent.Name,
                    OrgEventStartTime = orgEvent.StartTime,
                    OrgEventStatus = GetEventStatus(orgEvent.Status),
                    isOnGoing = isOnGoing(orgEvent.StartTime)
                };
                result.OrgEvents.Add(eventToAdd);
            }

            return result;
        }
    }
}
