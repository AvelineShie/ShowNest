using System.Security.Policy;

namespace ShowNest.Web.ViewModels.UserAccount

{
    public class UserAccountViewModel
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        //public int PhoneNumberCode { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
        public List<ActivityRegion> PreferredActivityRegions { get; set; }

        public string WebsiteUrl { get; set; }
        public ThirdPartyLink Fb { get; set; }
        public ThirdPartyLink Google { get; set; }

        public string Bio { get; set; }
        //public string Country { get; set; }
        //public TimeZone TimeZone { get; set; }
        public bool IsSubscribed { get; set; }
        //public bool RestrictedLevel { get; set; }
        //public bool OpenPersonalPage { get; set; }
        public string ImageUrl { get; set; }
    }
    public enum Gender
    {
        Male = 0,
        Female = 1,
        Other = 2
    };

    public enum ActivityRegion
    {
        Region1 = 0,
        Region2 = 1,
        Region3 = 2
    }
    public class ThirdPartyLink
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Scope { get; set; }
        public string Redirect_uri_encode { get; set; }
        public string State { get; set; }
    }

}
