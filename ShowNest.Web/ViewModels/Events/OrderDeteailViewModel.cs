using ShowNest.Web.ViewModels.UserAccount;

namespace ShowNest.Web.ViewModels.Events
{
    public class OrderDeteailViewModel
    {
        public EventDetailsViewModel EventDetails { get; set; }
        public SeatsViewModel Seats { get; set; }
        public TicketsViewModel Tickets { get; set; }
        public PaymentMethodViewModel PaymentMethod { get; set; }
        public PrefillsInfoViewModel PrefillsInfo { get; set; }
    }
}
