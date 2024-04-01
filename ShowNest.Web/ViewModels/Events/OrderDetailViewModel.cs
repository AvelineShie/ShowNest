using ShowNest.Web.ViewModels.UserAccount;
using System.ComponentModel.DataAnnotations;

namespace ShowNest.Web.ViewModels.Events
{
    public class OrderDetailViewModel
    {

        public List<MemberCenterOrders> MemberCenterOrders {  get; set; }
        // Event Status
       
    }
    public class MemberCenterOrders
    {
        public int OrderId {  get; set; }
        public int UserId { get; set; }

        // Event Information
        public string EventName { get; set; }
        public string EventHost { get; set; }
        public string GetTicketMethod { get; set; }
        public int OrderStatus { get; set; }


        //public string RefundPolicy { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
      
        public string EventLocation { get; set; }
        public string EventAddress { get; set; }


        // Payment Method Information
        public byte PaymentMethod { get; set; }
        //public int BankID { get; set; }
        //public int BankAccountNumber { get; set; }
        //public string PaymentCode { get; set; }
        //public string BankName { get; set; }
        //public string AccountName { get; set; }
        public decimal TotalPrice { get; set; }
        //public DateTime EndPayTime { get; set; }

        // Prefill Info
        public string UserName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public List<AllTickets> AllTickets { get; set; }

    }
    public class AllTickets
    {
        public int TicketTypeId { get; set; }

        public string TicketTypeName { get; set; }
        public int TicketId { get; set; }
        public string TicketNumber { get; set; }
        public int SeatAreaId { get; set; }
        public string SeatArea { get; set; }
        public int SeatsId { get; set; }
        public int SeatNumber { get; set; }
        public decimal TicketPrice { get; set; }
        public int PurchaseAmount { get; set; }
    }


}
