using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.Services.TicketTypes;
using ShowNest.Web.ViewModels.EventsApiDtos;
using ShowNest.Web.ViewModels.Tickets;
using Organization = ShowNest.Web.ViewModels.EventsApiDtos.Organization;

namespace ShowNest.Web.WebAPI;

[Route("api/[controller]/[action]")]
[ApiController]
public class TicketTypesController : ControllerBase
{
    private readonly ITicketTypeService _ticketTypeService;

    public TicketTypesController(ITicketTypeService ticketTypeService)
    {
        _ticketTypeService = ticketTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTicketTypeSelection(int eventId)
    {
        var ticketTypes = await _ticketTypeService.GetTicketTypesByEventId(eventId);

        return Ok(ticketTypes);
    }

    [HttpPost]
    public async Task<IActionResult> GetAutoSelectedSeats(AutoSeatSelectionRequestViewModel request)
    {
        var tickets = await _ticketTypeService.GetAutoSelectedSeats(request);

        return Ok(tickets);
    }

    [HttpPost]
    public async Task<IActionResult> GetAvailableTickets(AutoSeatSelectionRequestViewModel request)
    {
        var tickets = await _ticketTypeService.GetAvailableTickets(request);

        return Ok(tickets);
    }
}