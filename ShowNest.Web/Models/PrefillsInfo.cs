namespace ShowNest.Web.Models
{
    public class PrefillsInfo
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int? PostalCode { get; set; }
        public string Address { get; set; }
        public string OrganiztionName { get; set; }
        public string JobTitle { get; set; }
        public int? CompanyZipCode { get; set; }
        public string CompanyAddress { get; set; }
        public int? CompanyVAT { get; set; }
        public int? DonateEInvoice { get; set; }
        public string MobileEInvoice { get; set; }

        public virtual User User { get; set; }
    }
}
