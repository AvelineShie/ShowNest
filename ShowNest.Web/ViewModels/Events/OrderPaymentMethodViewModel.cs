namespace ShowNest.Web.ViewModels.Events
{
    public class OrderPaymentMethodViewModel
    {
        public EventDetailsViewModel EventDetails { get; set; }
        public SelectSeatsViewModel SelectSeats { get; set; }
        public TicketTypeViewModel TicketType { get; set; }
        public PaymentMethodViewModel PaymentMethod { get; set; }
        public string IdNumber {  get; set; }
    }
}
