using ShowNest.Web.ViewModels.Organization;

namespace ShowNest.Web.Services.Organizations;

public class OrganizationDetailService
{
    public OrganizationDetailService()
    {
        var Organization = new OrganizationIndexViewModel
        {
            OrganizationId = 1,
            OrganizationName = "音樂之友協會",
            OrganizationImgUrl = "https://example.com/organization1.jpg",
            OrganizationDescription = "音樂之友協會致力於促進音樂文化的發展，舉辦各類音樂活動和表演，讓更多人欣賞到優質的音樂作品。",
            OrganizationWeb = "https://example.com/music-friends",
            OrganizationFBLink = "https://www.facebook.com/musicfriends",
            OrganizationEmail = "contact@musicfriends.org"

        };
    }
}
