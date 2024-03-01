namespace ShowNest.Web.ViewModels.Events
{
    public class EventDetailsViewModel
    {
        public string EventName {  get; set; }
        public DateTime DateTime { get; set; }
        public string EventId { get; set; }
        
        public string Location {  get; set; }
        public string Organizers {  get; set; }
        public TicketTypeViewModel TicketType { get; set; }
        public PaymentMethodViewModel PaymentMethod {  get; set; }
        
    }
}
