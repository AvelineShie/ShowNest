namespace ShowNest.Web.ViewModels.Tickets;

public class AutoSeatSelectionResponseViewModel
{
    public List<AutoSelectedSeatViewModel> Tickets { get; set; }
}

public class AutoSelectedSeatViewModel
{
    public decimal Price { get; set; }

    public int SeatAreaId { get; set; }

    public string SeatAreaName { get; set; }

    public string SeatNumber { get; set; }

    public string TicketTypeName { get; set; }
}