using ApplicationCore.Entities;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShowNest.Web.ViewModels.Dashboard;
using ShowNest.Web.ViewModels.Shared;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using static ShowNest.Web.ViewModels.Dashboard.OrgNameList;

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

        [Route("/api/CreateEvent/CreateEventbyUserId")] //組織選單
        public async Task<IActionResult> CreateEventbyUserId()
        {
            var userIdFromClaim = _httpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdFromClaim == null)
            {
                return null;
            }
            else
            {
                //找使用者與其下組織
                var info = await _context.Users
                               .Include(u => u.OrganizationAndUserMappings)
                               .ThenInclude(ou => ou.Organization)
                               .FirstOrDefaultAsync(x => x.Id == int.Parse(userIdFromClaim.Value));

                //設定Org下拉選單內容
                List<OrgNameList> Organizations = new List<OrgNameList>();
                foreach(var org in info.Organizations.OrderBy(o => o.Id))
                {
                    OrgNameList orgNameList = new OrgNameList
                    {
                        OrgId = org.Id,
                        OrgName = org.Name
                    };
                    Organizations.Add(orgNameList);
                }

                return Ok(Organizations);
            }
        }

        //已有活動選項
        [Route("/api/CreateEvent/GetActivitiesByOrgId")]
        public async Task<IActionResult> fetchActivitiesByOrgId()
        {
            var userIdFromClaim = _httpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdFromClaim == null)
            {
                return null;
            }
            else
            {
                var eventInfo = await _context.Users
                               .Include(u => u.OrganizationAndUserMappings)
                               .ThenInclude(ou => ou.Organization)
                               .ThenInclude(o => o.Events)
                               .FirstOrDefaultAsync(u => u.Id == int.Parse(userIdFromClaim.Value));


                List<OrgNameList> Organizations = new List<OrgNameList>();
                List<EventNameList> Events = new List<EventNameList>();

                foreach (var org in eventInfo.Organizations.OrderBy(o => o.Id))
                {

                    OrgNameList orgNameList = new OrgNameList
                    {
                        OrgId = org.Id,
                        OrgName = org.Name
                    };
                    Organizations.Add(orgNameList);

                    foreach (var activity in org.Events)
                    {
                        EventNameList eventNameList = new EventNameList
                        {
                            EventId = activity.Id,
                            EventName = activity.Name
                        };

                        Events.Add(eventNameList);
                    }
                    
                }

                return Ok(Events);
            }


        }

        [HttpPost] //示範
        public IActionResult CreateNewEvent(CreateNewEventDto request)
        {
            return Ok(new
            {
                IsSuccess = true
            });
        }

        [HttpPost] //建立全新活動
        public IActionResult CreateAndEditEvent(CreateEventDto request)
        {
            var newEventId = _CreateEventService.CreateEvent(request);
            request.EditedAt = DateTime.Now;

            return Ok(new
            {
                IsSuccess = true,
                Id = newEventId,

            });
            
        }

        //渲染
        [HttpGet]
        [Route("/api/CreateEvent/RenderEventData")]
        public IActionResult RenderEventData([FromQuery] int eventId)
        {
            try
            {
                var selectedEventId = _CreateEventService.EditEventRender(eventId);
                var successResult = OperationResultHelper.ReturnSuccessData(selectedEventId);
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


