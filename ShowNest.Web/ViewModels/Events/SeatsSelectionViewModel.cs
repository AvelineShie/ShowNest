namespace ShowNest.Web.ViewModels.Events
{
    public class SeatsSelectionViewModel
    {
        public DateTime ExpireTime { get; set; }
        public string SeatAreaName { get; set; }
        public List<List<Seat>> Seats { get; set; }
        public List<Ticket> Tickets { get; set; }
    }

    public class Seat
    {
        public int SeatId { get; set; }
        public int SeatAreaId { get; set; }
        public string SeatNumber { get; set; }
        public int SeatStatus { get; set; }
    }

    public class Ticket
    {
        public decimal SubTotal { get; set; }
        public string TicketTypeName { get; set; }
        public string SeatAreaName { get; set; }
        public string SeatNumber { get; set; }
        public decimal TicketPrice { get; set; }
    }
    
}

