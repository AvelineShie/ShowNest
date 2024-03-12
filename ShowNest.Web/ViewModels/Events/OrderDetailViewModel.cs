using ShowNest.Web.ViewModels.UserAccount;
using System.ComponentModel.DataAnnotations;

namespace ShowNest.Web.ViewModels.Events
{
    public class OrderDetailViewModel
    {
        // Event Status
        public string OrderStatus {  get; set; }

        // Event Information
        public string EventName { get; set; }
        public string EventHost { get; set; }
        public string GetTicketMethod { get; set; }

        public string RefundPolicy {  get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{~ 0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
        public string EventLocation { get; set; }
        public string EventAddress { get; set; }

        // Order Id
        public string OrderId { get; set; }

        // Payment Method Information
        public string PaymentMethod { get; set; }
        public int BankID { get; set; }
        public int BankAccountNumber { get; set; }
        public string PaymentCode { get; set; }
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime EndPayTime { get; set; }

        // Prefill Info
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


        // Ticket Information
        public string SeatArea { get; set; }
        public string SeatRow { get; set; }
        public int SeatNumber { get; set; }
        public string TicketTypeName { get; set; }
        public int PurchaseAmount { get; set; }
        public string RegistrationSerialNumber { get; set; }
       

    }
   
}
