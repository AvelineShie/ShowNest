using ShowNest.Web.ViewModels.Tickets;

namespace ShowNest.Web.ViewModels.Orders;

public class CreateOrderRequest
{
    public List<AutoSelectedSeatViewModel> Tickets { get; set; }

    public ContactInformationViewModel ContactInformation { get; set; }

    public int EventId { get; set; }
}