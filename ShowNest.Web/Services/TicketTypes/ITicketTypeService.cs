using ShowNest.Web.ViewModels.Tickets;

namespace ShowNest.Web.Services.TicketTypes;

public interface ITicketTypeService
{
    Task<TicketTypeSelectionViewModel> GetTicketTypesByEventId(int eventId);
    
    Task<AutoSeatSelectionResponseViewModel> GetAutoSelectedSeats(AutoSeatSelectionRequestViewModel request);
    Task<AvailableTicketsResponseViewModel> GetAvailableTickets(AutoSeatSelectionRequestViewModel request);
}