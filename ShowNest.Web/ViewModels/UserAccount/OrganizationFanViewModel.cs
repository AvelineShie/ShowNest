namespace ShowNest.Web.ViewModels.UserAccount
{
    public class OrganizationFanViewModel
    {
       public List<Organization> Organizations { get; set; }
       public int page { get; set; }
    }
    public class Organization
    {
        public string OrgName { get; set; }
        public string OrgId { get; set; }
        public DateTime TimeJoin { get; set; }
    }
}
