using ShowNest.Web.ViewModels.UserAccount;
using System.ComponentModel.DataAnnotations;

namespace ShowNest.Web.ViewModels.Events
{
    public class RegistrationViewModel
    {
        // Event Information
        public string MainImage { get; set; }
        public string EventName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        public string EventId { get; set; }
        public string EventLocation { get; set; }
        public string EventAddress { get; set; }
        public string EventHost { get; set; }
        public string TicketCollectionChannel { get; set; }
        public string PaymentMethodName { get; set; }

        // Ticket Information
        public List<Tickets> TicketSeats { get; set; }
       

        // Attendee Information
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        // Additional Information
        public bool ShownParticipatedCampaign { get; set; }

    }
    public class Tickets
    { 
        public string SeatArea { get; set; }
        public string SeatRow { get; set; }
        public int SeatNumber { get; set; }
        public string TicketTypeName { get; set; }
        public decimal TicketPrice { get; set; }
        public int PurchaseAmount { get; set; }
        public decimal TotalPrice { get; set; }

    }



}
