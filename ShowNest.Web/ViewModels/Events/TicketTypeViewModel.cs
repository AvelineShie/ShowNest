using System.Data.SqlTypes;

namespace ShowNest.Web.ViewModels.Events
{
    public class TicketTypeViewModel
    {
        public string TicketType {  get; set; }
        public decimal TicketPrice { get; set; }
        public int  TicketCount { get; set; }
        public decimal TotalAmount {  get; set; }
    }
}
