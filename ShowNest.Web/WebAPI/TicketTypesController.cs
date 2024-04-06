using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.Services.TicketTypes;
using ShowNest.Web.ViewModels.EventsApiDtos;
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
}