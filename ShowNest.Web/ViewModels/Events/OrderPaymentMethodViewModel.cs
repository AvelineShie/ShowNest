namespace ShowNest.Web.ViewModels.Events
{
    public class OrderPaymentMethodViewModel
    {
        public EventDetailsViewModel EventDetails { get; set; }
        public SeatsViewModel Seats { get; set; }
        public TicketsViewModel Tickets { get; set; }
        public PaymentMethodViewModel PaymentMethod { get; set; }
        public string IdNumber {  get; set; }
    }
}
