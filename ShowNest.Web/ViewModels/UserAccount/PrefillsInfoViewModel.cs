namespace ShowNest.Web.ViewModels.UserAccount
{
    public class PrefillsInfoViewModel
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
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


}
