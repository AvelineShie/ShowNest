using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ShowNest.Web.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventsOverviewApiController : ControllerBase
    {
        private readonly IEventOverviewService _eventOverviewService;

        public EventsOverviewApiController(IEventOverviewService eventOverviewService)
        {
            _eventOverviewService = eventOverviewService;
        }

        public async Task<IActionResult> GetEventsOverviewDto(int eventId)
        {
            try
            {
                var eventsOverviewDto = await _eventOverviewService.GetEventsOverviewTicketInfo(eventId);
                return Ok(eventsOverviewDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
