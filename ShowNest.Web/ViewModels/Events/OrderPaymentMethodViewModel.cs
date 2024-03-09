using System.ComponentModel.DataAnnotations;

namespace ShowNest.Web.ViewModels.Events
{
    public class OrderPaymentMethodViewModel
    {
        // Event Information
        public string MainImage { get; set; }
        public string EventName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{~ 0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
        public string EventId { get; set; }
        public string EventLocation { get; set; }
        public string EventAddress { get; set; }
        public string EventHost { get; set; }
        public string TicketCollectionChannel { get; set; }
        public string PaymentMethod { get; set; }

        // Ticket Information
        public string SeatArea { get; set; }
        public string SeatRow { get; set; }
        public int SeatNumber { get; set; }
        public string TicketTypeName { get; set; }
        public decimal TicketPrice { get; set; }
        public int PurchaseAmount { get; set; }
        public decimal TotalPrice { get; set; }
       

        // Payment Method
        public bool FamilyMartGetTicket { get; set; } 
        public string IdNumber { get; set; }
        public string GetTicketMethod { get; set; }
        public bool AtmVirtualAccount { get; set; }
       
    }

}


