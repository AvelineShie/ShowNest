using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowNest.ApplicationCore.DTOs;

namespace ShowNest.Web.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventsIndexController : ControllerBase
    {
        private readonly EventsIndexCardsAPIServiceByEf _eventsIndexCardsAPIServiceByEf;

        public EventsIndexController(EventsIndexCardsAPIServiceByEf eventsIndexCardsAPIServiceByEf)
        {
            _eventsIndexCardsAPIServiceByEf = eventsIndexCardsAPIServiceByEf;
        }

        //public async Task<IActionResult> GetEventsIndexCardsByApi(int page, int cardsPerPage)
        //{
        //    return Ok(await _eventsIndexCardsAPIServiceByEf.GetCardsByPagesize(page, cardsPerPage));
        //}

        public async Task<IActionResult> GetEventsIndexCardsByApi([FromBody]QueryParametersDto request)
        {
            return Ok(await _eventsIndexCardsAPIServiceByEf.GetCardsByPagesize(request));
        }

    }
}
