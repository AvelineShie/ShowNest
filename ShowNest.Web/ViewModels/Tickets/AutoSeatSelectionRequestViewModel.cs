namespace ShowNest.Web.ViewModels.Tickets;

public class AutoSeatSelectionRequestViewModel
{
    public List<TicketTypeTicketCountViewModel> Criteria { get; set; }
}

public class TicketTypeTicketCountViewModel
{
    public int TicketTypeId { get; set; }

    public int TicketCount { get; set; }
}