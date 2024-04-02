namespace ShowNest.Web.ViewModels.Shared
{
    public class HeaderNavInfoViewModel
    {
        public string UserName { get; set; }
        public string UserImgUrl { get; set; }
        public List<UserOrgInfo> UserOrg { get; set; }
    }

    public class UserOrgInfo
    {
        public string UserOrgId { get; set; }
        public string UserOrgName { get; set; }
        public string UserOrgUrl { get; set; }
    }
}
