namespace ShowNest.Web.Models
{
    public class PrefillsInfo
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        public int? PostalCode { get; set; }
        public string Address { get; set; }
        public string OrganiztionName { get; set; }
        public string Title { get; set; }
        public int? CompanyZipCode { get; set; }
        public string CompanyAddress { get; set; }
        public int? CompanyVAT { get; set; }
        public int? DonateEInvoice { get; set; }
        public string MobileEInvoice { get; set; }

        public virtual User User { get; set; }
    }
}
