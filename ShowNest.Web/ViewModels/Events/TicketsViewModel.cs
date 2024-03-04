using System.Data.SqlTypes;

namespace ShowNest.Web.ViewModels.Events
{
    public class TicketsViewModel
    {
        public string TicketTypeName { get; set; }
        public decimal TicketPrice { get; set; }
        public int  PurchaseAmount { get; set; }
    }
}
