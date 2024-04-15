using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShowNest.Web.ViewModels.EventsApiDtos;
using ShowNest.Web.ViewModels.Shared;
using System.Security.Claims;

namespace ShowNest.Web.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreateEventController : ControllerBase
    {

        //private readonly EventsApiService _eventsApiService;
        //private readonly DatabaseContext _context;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public EventsController(EventsApiService eventsApiService, DatabaseContext context, IHttpContextAccessor httpContextAccessor)
        //{
        //    _eventsApiService = eventsApiService;
        //    _context = context;
        //    _httpContextAccessor = httpContextAccessor;
        //}

    }
}
