using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.Services
{

    //public class CreateEventService : EfRepository<Event>, ICreateEventService
    //{
    //    //抓使用者登入ID用的
    //    //private readonly IHttpContextAccessor _httpContextAccessor;
    //    private readonly IOrganizationRepository _organizationRepository;
    //    private readonly DatabaseContext _dbContext;

    //    public CreateEventService(IOrganizationRepository organizationRepository, DatabaseContext context) : base(context)
    //    {
    //        _organizationRepository = organizationRepository;
    //        _dbContext = context;
    //    }

    //    public IEnumerable<Organization> GetOrgByUserId(int userId)
    //    {
    //        var organizations = DbContext.Organizations
    //            .Where(o => o.OwnerId == userId);

    //        return organizations;
    //    }

    //    public IEnumerable<Event> GetOrgEventsByOrgId(int orgId)
    //    {
    //        var events = DbContext.Events
    //            .Include(e => e.Organization)
    //            .Where(e => e.OrganizationId == orgId);

    //        return events;
    //    }

    //    //如果要跳轉到活動頁面,活動主頁已經有API，類型可以直接設string，
    //    //return為result.id（如果活動頁面是用id去撈）

    //    //public Event CreateEvent(CreateEventDto require)
    //    //{
    //    //    //四頁包一個交易?
    //    //    //但不同資料要給不同的資料表,分開?
    //    //    using (var transcation = DbContext.Database.BeginTransaction())
    //    //        try
    //    //        {
    //    //            // 將列表轉 JSON 字串
    //    //            var contactPersonJson = JsonConverter.SerializeObject(require.ContactPerson);
    //    //            var participantPeopleJson = JsonContent.SerializeObject(require.ParticipantPeople);



    //    //            //設定活動資料
    //    //            var activity = new Event
    //    //            {
    //    //                Id = require.EventId,
    //    //                Name = require.EventName,
    //    //                OrganizationId = require.OrgId,
    //    //                StartTime = require.StartTime,
    //    //                EndTime = require.EndTime,
    //    //                Type = require.EventStatus,
    //    //                LocationName = require.LocationName,
    //    //                LocationAddress = require.EventAddress,
    //    //                Longitude = require.Longitude,
    //    //                Latitude = require.Latitude,
    //    //                //還有一欄給使用者自填活動主頁網址,視情況再放
    //    //                StreamingPlatform = require.StreamingName,
    //    //                StreamingUrl = require.StreamingUrl,
    //    //                Capacity = require.Attendance,
    //    //                ContactPerson = contactPersonJson,
    //    //                ParticipantPeople = participantPeopleJson,
    //    //                EventImage = require.EventImage,
    //    //                Introduction = require.EventIntroduction,
    //    //                Description = require.EventDescription,
    //    //                MainOrganizer = require.MainOrganizer,
    //    //                CoOrganizer = require.CoOrganizer,
    //    //                IsPrivateEvent = require.IsPrivateEvent,
    //    //                IsFree = require.IsFree,
    //    //                Sort = require.Sort, //排序
    //    //                IsDeleted = false,
    //    //                CreatedAt = require.CreatedAt,
    //    //                EditedAt = require.EditedAt
    //    //            };
    //    //            DbContext.Events.Add(activity); 
    //    //            DbContext.SaveChanges();

    //    //            //活動標籤
    //    //            var eventTags = new EventAndTagMapping
    //    //            {
    //    //                EventId = require.EventId,
    //    //                CategoryTagId = require.CategoryId,
    //    //            };


    //    //            DbContext.EventAndTagMappings.Add(eventTags);
    //    //            DbContext.SaveChanges();

    //    //            //TicketTypes: 活動與票卷的關係
    //    //            //TicketType線上是複數啊!!!

    //    //            var ticketDetail = new TicketType
    //    //            {
    //    //                EventId = require.EventId,
    //    //                Name = require.TicketName,
    //    //                StartSaleTime = require.StartSaleTime,
    //    //                EndSaleTime = require.EndSaleTime,
    //    //                Price = require.Prince,
    //    //                CapacityAmount = require.Amount,

    //    //            };
    //    //            DbContext.TicketTypes.Add(ticketDetail);
    //    //            DbContext.SaveChanges();



    //    //            transcation.Commit();
    //    //            //不用丟給活動主頁,那就?
    //    //            return activity;
                    
    //    //        }
    //    //        catch (Exception ex) {
    //    //            transcation.Rollback();
    //    //            throw new Exception(ex.Message);
    //    //        }
            
    //    //}





    //    public EventAndTagMapping Add(EventAndTagMapping entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<EventAndTagMapping> AddRange(IEnumerable<EventAndTagMapping> entities)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public EventAndTagMapping Update(EventAndTagMapping entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<EventAndTagMapping> UpdateRange(IEnumerable<EventAndTagMapping> entities)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(EventAndTagMapping entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void DeleteRange(IEnumerable<EventAndTagMapping> entities)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    EventAndTagMapping IRepository<EventAndTagMapping>.GetById<TId>(TId id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public EventAndTagMapping FirstOrDefault(Expression<Func<EventAndTagMapping, bool>> expression)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public EventAndTagMapping SingleOrDefault(Expression<Func<EventAndTagMapping, bool>> expression)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Any(Expression<Func<EventAndTagMapping, bool>> expression)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<EventAndTagMapping> List(Expression<Func<EventAndTagMapping, bool>> expression)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    List<EventAndTagMapping> IRepository<EventAndTagMapping>.All()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<EventAndTagMapping> UpdateAsync(EventAndTagMapping entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Task<EventAndTagMapping> IRepository<EventAndTagMapping>.GetByIdAsync<TEntityId>(TEntityId id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //};
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





