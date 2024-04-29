namespace ShowNest.Web.ViewModels.Tickets;

public class AvailableTicketsResponseViewModel
{
    public List<AvailableTicketViewModel> Tickets { get; set; }
}

public class AvailableTicketViewModel
{
    public decimal Price { get; set; }

    public string TicketTypeName { get; set; }

    public int TicketId { get; set; }

    public bool HasSeat { get; set; } = false;
}