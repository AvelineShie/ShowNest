namespace ShowNest.Web.ViewModels.Events
{
    public class SeatsSelectionViewModel
    {
        public DateTime ExpireTime { get; set; }
        public string SeatAreaName { get; set; }
        public List<List<SeatViewModel>> Seats { get; set; }
        public List<TicketViewModel> Tickets { get; set; }
    }

    public class SeatViewModel
    {
        public int SeatId { get; set; }
        public int SeatAreaId { get; set; }
        public string SeatNumber { get; set; }
        public int SeatStatus { get; set; }
    }

    public class TicketViewModel
    {
        public decimal SubTotal { get; set; }
        public string TicketTypeName { get; set; }
        public string SeatAreaName { get; set; }
        public string SeatNumber { get; set; }
        public decimal TicketPrice { get; set; }
    }
    
}

