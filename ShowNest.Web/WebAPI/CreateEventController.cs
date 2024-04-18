using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.ViewModels.Shared;
using System.Security.Claims;

namespace ShowNest.Web.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreateEventController : ControllerBase
    {

        //private readonly EventsApiService _eventsApiService;
        private readonly DatabaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICreateEventService _CreateEventService;

        public CreateEventController(ICreateEventService createEventInterface, DatabaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _CreateEventService = createEventInterface;
        }

        //從使用者抓取組織id,然後再用組織id抓活動id
        [HttpPost]
        [Route("/api/CreateEvent/CreateEventbyUserId")]
        //public async Task<OrgsEventsInfroViewModel> CreateEventbyUserId()
        //{
        //    //從Claim抓UserID
        //    var userIdFromClaim = _httpContextAccessor.HttpContext.User.Claims
        //            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        //    if (userIdFromClaim == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        var info = await _context.Users
        //                        .Include(u => u.OrganizationAndUserMappings)
        //                        .ThenInclude(ou => ou.Organization)
        //                        .FirstOrDefaultAsync(x => x.Id == int.Parse(userIdFromClaim.Value));

        //        var result = new OrgsEventsInfroViewModel();
        //        result.UserOrg = new List<EventsInfro>();
        //        foreach (var org in info.Organizations.OrderBy(o => o.Id))
        //        {
        //            var orgToAdd = new UserOrgInfo
        //            {
        //                UserOrgId = org.Id.ToString(),
        //                UserOrgName = org.Name,
        //                UserOrgUrl = $"{org.Name}URL"
        //            };
        //            result.UserOrg.Add(orgToAdd);
        //        }
        //        result.UserImgUrl = "https://picsum.photos/300/200/?random=10";

        //        return result;

        //    }
        //    return info;
        //    //先用UserId抓出OrgId,OrgName,然後foreach丟進前端的JS的organization
        //}


        //[HttpPost]
        //[Route("/api/CreateEvent/CreateAndEditEvent")]
        //public IActionResult CreateAndEditEvent(CreateEventDto request)
        //{
        //    try
        //    { 

        //        //int newEventId;
        //        if (request.EventId == 0)
        //        {   //取得使用者登入資訊:在view驗證即可
        //            //var userIdFromClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        //            //request.EventId = int.Parse(userIdFromClaim.Value);
        //            request.CreatedAt = DateTime.Now;
        //            newEventId = _CreateEventService.CreateEvent(request);
        //        }
        //        // 若有活動id, 則進入修改活動
        //        else
        //        {
        //            newEventId = _CreateEventService.UpdateEvent(request);
        //        }
        //        var successResult = OperationResultHelper.ReturnSuccessData(newEventId);
        //        return Ok(successResult);
        //    }
        //    catch
        //    (Exception ex)
        //    {
        //        var errorResult = OperationResultHelper.ReturnErrorMsg(ex.Message);
        //        return BadRequest(errorResult);
        //    }
        //}

        //以活動id打路由去呼叫頁面的資料
        [Route("{eventId}")]
        public IActionResult RenderEventData(string eventId)
        {
            try
            {
                var newEvent = _CreateEventService.RenderEventData(int.Parse(eventId));
                var successResult = OperationResultHelper.ReturnSuccessData(newEvent);
                return Ok(successResult);
            }
            catch (Exception ex)
            {
                var errorResult = OperationResultHelper.ReturnErrorMsg(ex.Message);
                return BadRequest(errorResult);
            }
        }
    }



}


