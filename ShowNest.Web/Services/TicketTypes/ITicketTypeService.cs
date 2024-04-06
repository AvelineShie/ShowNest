namespace ShowNest.Web.Services.TicketTypes;

public interface ITicketTypeService
{
    Task<TicketTypeSelectionViewModel> GetTicketTypesByEventId(int eventId);
}