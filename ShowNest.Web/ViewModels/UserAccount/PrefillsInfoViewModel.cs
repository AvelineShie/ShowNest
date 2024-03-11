namespace ShowNest.Web.ViewModels.UserAccount
{
    public class PrefillsInfoViewModel
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public List<Country> Country { get; set; }
        public List<City> City { get; set; }
        public string Region { get; set; }
        public int PostalCode { get; set; }
        public string Address { get; set; }
        public string OrganiztionName { get; set; }
        public string JobTitle { get; set; }
        public int CompanyZipCode { get; set; }
        public string CompanyAddress { get; set; }
        public int CompanyVAT { get; set; }
        public List<DonateOrg> DonateEInvoice { get; set; }
        public string MobileEInvoice { get; set; }

    }
    public enum DonateOrg
    {
        DonateOrg1=0,
        DonateOrg2=1
    }
    public enum Country
    {
        Region1 = 0,
        Region2 = 1,
        Region3 = 2
    }
    public enum City
    {
        Region1 = 0,
        Region2 = 1,
        Region3 = 2
    }

}
