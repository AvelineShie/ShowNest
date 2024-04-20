using ApplicationCore.Entities;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShowNest.Web.ViewModels.Dashboard;
using ShowNest.Web.ViewModels.Shared;
using System.Collections.Generic;
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

        [HttpPost]
        [Route("/api/CreateEvent/CreateEventbyUserId")]
        public IActionResult CreateEventbyUserId()
        {
            var userIdFromClaim = _httpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdFromClaim == null)
            {
                return null;
            }
            else
            {   
                var user = _context.Users
                .Include(u => u.OrganizationAndUserMappings)
                .FirstOrDefaultAsync(u => u.Id == int.Parse(userIdFromClaim.Value));

                if (user == null)
                {
                    return null;
                }

                // 找與登入者相同的使用者ID，並且找出該ID下的所有組織名稱

                string sqlQuery = @"
                    SELECT o.Name
                    FROM Organizations o
                    INNER JOIN OrganizationAndUserMapping om ON o.Id = om.OrganizationId
                    WHERE om.UserId = o.Id";

                var orgNames = _context.Organizations
                    .FromSqlRaw(sqlQuery, new SqlParameter("@userId", userIdFromClaim.Value))
                    .Select(o => o.Name)
                    .ToList();

                return new JsonResult(orgNames); // 返回Json組織名稱表

            }
        }



        [HttpPost]
        [Route("/api/CreateEvent/CreateAndEditEvent")]
        public IActionResult CreateAndEditEvent(CreateEventDto request)
        {
            try
            {
                int newEventId;
                if (request.EventId == 0)
                {   //取得使用者登入資訊:在view驗證即可
                    var userIdFromClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                    request.EventId = int.Parse(userIdFromClaim.Value);
                    request.CreatedAt = DateTime.Now;
                    newEventId = _CreateEventService.CreateEvent(request);
                }
                //若有活動id, 則進入修改活動
                else
                {
                    newEventId = _CreateEventService.UpdateEvent(request);
                }
                var successResult = OperationResultHelper.ReturnSuccessData(newEventId);
                return Ok(successResult);
            }
            catch
            (Exception ex)
            {
                var errorResult = OperationResultHelper.ReturnErrorMsg(ex.Message);
                return BadRequest(errorResult);
            }
        }

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


