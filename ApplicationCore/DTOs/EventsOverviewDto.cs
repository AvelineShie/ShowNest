using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOs
{
    public class EventsOverviewDto
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int AllSoldTicketsCount { get; set; }
        public int AllRemainedTicketsCount { get; set; }
        public int AllTicketsAmount { get; set; }
        public string EventTime { get; set; }
        public string EventPlace { get; set; }
        public List<EventsOverviewTicketsDto>? Tickets { get; set; }
        public List<EventsOverviewOrdersDto>? Orders { get; set; }
    }
    public class EventsOverviewTicketsDto
    {
        public int TicketTypeId { get; set; }
        public string TicketTypeName { get; set; }
        public string StartSellingTime { get; set; }
        public string EndSellingTime { get; set;}
        public bool SellingStatus { get; set; }
        public int Price { get; set; }
        public int SoldAmount { get; set;}
        public int PaidAmount { get; set; }
        public int WaitingToPayAmount { get; set; }
        public int RemainAmount { get; set; }
        public int PriceOfPaidAmout { get; set; }
    }

    public class EventsOverviewOrdersDto
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public int OrderedTicketAmount { get; set; }
        public int OrderedTicketTotalPrice { get; set; }
    }
}
