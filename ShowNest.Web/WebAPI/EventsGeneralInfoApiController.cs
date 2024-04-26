using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShowNest.Web.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventsGeneralInfoApiController : ControllerBase
    {
        private readonly EventGeneralInfoApiService _eventGeneralInfoApiService;

        public EventsGeneralInfoApiController(EventGeneralInfoApiService eventGeneralInfoApiService)
        {
            _eventGeneralInfoApiService = eventGeneralInfoApiService;
        }

        public async Task<IActionResult> GetEventGeneralInfoDtoByApi(int eventId)
        {
            var result = await _eventGeneralInfoApiService.GetEventGeneralInfoDtoByEventId(eventId);
            return Ok(result);
        }
    }
}
