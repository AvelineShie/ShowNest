using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    public class EventsOverviewTicketsDto
    {
        public int EventId { get; set; }
        public int TicketTypeId { get; set; }
        public string TicketTypeName { get; set; }
        public string StartSellingTime { get; set; }
        public string EndSellingTime { get; set;}
        public bool SellingStatus { get; set; }
        public int Price { get; set; }
        public int SoldAmount { get; set;}
        public int PaidAmout { get; set; }
        public int WaitingToPayAmout { get; set; }
        public int RemainAmout { get; set; }
        public int PriceOfPaidAmout { get; set; }
    }
}
