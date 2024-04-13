using ShowNest.Web.ViewModels.Dashboard;

namespace ShowNest.Web.Services.Dashboard
{
    public class OrgGeneralInfoService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrgGeneralInfoService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public OrgGeneralInfoViewModel GetOrgGeneralInfoViewModel(int orgId)
        {
            var org = _organizationRepository.GetOrgById(orgId);

            var result = new OrgGeneralInfoViewModel
            {
                OrgId = orgId,
                OrgName = org.Name,
                OrgWebUrl = org.OrganizationUrl,
                OrgDescription = org.Description,
                OrgFbUrl = org.Fblink,
                OrgIgUrl = org.Igaccount,
                OrgEmail = org.Email,
                OrgImgUrl = org.ImgUrl,
                OrgContactName = org.ContactName,
                OrgContactCellphone = org.ContactMobile,
                OrgContactTelepohone = org.ContactTelephone
            };

            return result;
        }
    }
}
