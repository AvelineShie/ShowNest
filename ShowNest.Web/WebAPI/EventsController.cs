using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.ViewModels.Shared;
using Microsoft.EntityFrameworkCore;
using ShowNest.Web.ViewModels.EventsApiDtos;
using Organization = ShowNest.Web.ViewModels.EventsApiDtos.Organization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ShowNest.Web.WebAPI;

[Route("api/[controller]/[action]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly EventsApiService _eventsApiService;
    private readonly DatabaseContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EventsController(EventsApiService eventsApiService, DatabaseContext context, IHttpContextAccessor httpContextAccessor)
    {
        _eventsApiService = eventsApiService;
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    

}


//[HttpPost]
//public IActionResult GetOrganizationsById([FromBody] GetOrganizationRequest request)
//{

//if (!ModelState.IsValid)
//{
//    return BadRequest(new
//    {
//        IsSuccess = false,
//        Message = "Invalid request"
//    });
//}

//var organizations = _eventsApiService.GetOrganizationsById(request.UserId);

//if ((organizations.Count <= 0)
//    {
//    return Ok(new { IsSuccess = false, Message = "No organization found" });
//}

//var result = new GetOrganizationResponse()
//{
//    Organizations = organizations.Select(x => new Organization()
//    {
//        Id = x.Id,
//        Name = x.Name
//    }).ToList()
//};

//return Ok(new { IsSuccess = true, Body = result });

//}