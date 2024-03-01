using ShowNest.Web.ViewModels.UserAccount;

namespace ShowNest.Web.ViewModels.Events
{
    public class OrderDeteailViewModel
    {
        public EventDetailsViewModel EventDetails { get; set; }
        public SelectSeatsViewModel SelectSeats { get; set; }
        public TicketTypeViewModel TicketType { get; set; }
        public PaymentMethodViewModel PaymentMethod { get; set; }
        public PrefillsInfoViewModel PrefillsInfo { get; set; }
    }
}
