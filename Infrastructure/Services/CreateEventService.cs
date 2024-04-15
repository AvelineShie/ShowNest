using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Azure.Core;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics.Tracing;
using System.Security.Cryptography;
using static ApplicationCore.DTOs.CreateEventDto;


namespace Infrastructure.Services
{

    public class CreateEventService : EfRepository<Organization>
    {
        //抓使用者登入ID用的
        //private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly DatabaseContext _dbContext;

        public CreateEventService(IOrganizationRepository organizationRepository, DatabaseContext context) : base(context)
        {
            _organizationRepository = organizationRepository;
            _dbContext = context;
        }


        //此頁寫全部頁面的資料處理邏輯
        //API CONTROLLER再呼叫這個SERVICE

        //================ CreateEvent Page ================
        public IEnumerable<Organization> GetOrgById(int userId)
        {
            var organizations = DbContext.Organizations
                .Where(o => o.OwnerId == userId);

            return organizations;
        }

        public IEnumerable<Event> GetOrgEventsByOrgId(int orgId)
        {
            var events = DbContext.Events
                .Include(e => e.Organization)
                .Where(e => e.OrganizationId == orgId);

            return events;
        }

        //============= SetEvent Page =====================
        //如果後面要跳轉到活動頁面,活動主頁已經有API，類型可以直接設string，
        //然後讓return為result.id（如果活動頁面是用id去撈）

        public  Event CreateEvent(CreateEventDto require)
        {
            //四頁包一個交易?
            //但不同資料要給不同的資料表,分開?
            using (var transcation = DbContext.Database.BeginTransaction())
                try
                {
                    // 將列表轉 JSON 字串
                    var contactPersonJson = JsonConvert.SerializeObject(require.ContactPerson);
                    var participantPeopleJson = JsonConvert.SerializeObject(require.ParticipantPeople);

                    //活動
                    var activity = new Event
                    {
                        Id = require.EventId,
                        Name = require.EventName,
                        OrganizationId = require.OrgId,
                        StartTime = require.StartTime,
                        EndTime = require.EndTime,
                        Type = require.EventStatus,
                        LocationName = require.LocationName,
                        LocationAddress = require.EventAddress,
                        Longitude = require.Longitude,
                        Latitude = require.Latitude,
                        //本來還有一欄給使用者自填活動主頁網址,先不放
                        StreamingPlatform = require.StreamingName,
                        StreamingUrl = require.StreamingUrl,
                        Capacity = require.Attendance,
                        ContactPerson = contactPersonJson,
                        ParticipantPeople = participantPeopleJson,
                        EventImage = require.EventImage,
                        Introduction = require.EventIntroduction,
                        Description = require.EventDescription,
                        MainOrganizer = require.MainOrganizer,
                        CoOrganizer = require.CoOrganizer,
                        IsPrivateEvent = require.IsPrivateEvent,
                        IsFree = require.IsFree,
                        Sort = require.Sort, //排序
                        IsDeleted = false,
                        CreatedAt = require.CreatedAt,
                        EditedAt = require.EditedAt
                    };
                    DbContext.Events.Add(activity); 
                    DbContext.SaveChanges();

                    //活動標籤
                    //活動與tag關係的表:EventAndTagMapping
                    var eventTags = new EventAndTagMapping
                    {
                        EventId = require.EventId,
                        //CategoryTagId = require.EventCategoryTags.CategoryId,
                    };

                    DbContext.EventAndTagMappings.Add(eventTags);
                    DbContext.SaveChanges();

                    //票卷
                    //票種,票區,張數,販售開始時間,結束時間,金額
                    var ticket = new Ticket
                    {

                    };

                    //欄位?


                    //不用丟給活動主頁,那就?
                    return activity;



                    
                }
                catch (Exception ex) {
                    transcation.Rollback();
                    throw new Exception(ex.Message);
                }
            
        }

        //糟糕小標籤是不同的資料表,要獨立寫嗎? 要吧?寫成巢狀的try catch?
        //Id = request.CategoryId
        //Name = request.CategoryName

        ////票,票種不同資料表應該要另外寫交易?
        //Id = request.TicketId


        //Id = request.TicketTypeId




    };
};
        //public CreateEventViewModel GetOrgByOwner(int OwnerId)
        //{
        //    // 根據 userID 找到它底下所有組織
        //    var organizations = _eventRepository.GetOrgsByOwnerId(OwnerId).ToList();

        //    // userID 所有組織 OrgId, OrgName組成VM
        //    var result = new CreateEventViewModel
        //    {
        //        OrgNames = new List<OrgNameList>()
        //    };

        //    if (result.OrgNames == null)
        //    {
        //        throw new NullReferenceException("OrgNames 屬性為空");
        //    }

        //    foreach (var org in organizations)
        //    {
        //        var newOrgNameList = new OrgNameList()
        //        {
        //            OrgId = org.Id,
        //            OrgName = org.Name,
        //        };

        //        result.OrgNames.Add(newOrgNameList);
        //    }
        //    return result;
        //}



    

