using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Infrastructure.Services
{

    public class CreateEventService : EfRepository<Event>, ICreateEventService
    {

        private readonly IOrganizationRepository _organizationRepository;
        private readonly DatabaseContext _dbContext;

        public CreateEventService(IOrganizationRepository organizationRepository, DatabaseContext context) : base(context)
        {
            _organizationRepository = organizationRepository;
            _dbContext = context;
        }

        public IEnumerable<Organization> GetOrgByUserId(int userId)
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

        //如果要跳轉到活動頁面,活動主頁設定用id去撈, 目前已經有API，類型可以直接設string，

        public int CreateEvent(CreateEventDto require)
        {

            //會用到不同資料表的部分分開寫
            using (var transcation = DbContext.Database.BeginTransaction())
                try
                {
                    // 將列表轉 JSON 字串
                    var contactPersonJson = JsonConvert.SerializeObject(require.ContactPerson);
                    var participantPeopleJson = JsonConvert.SerializeObject(require.ParticipantPeople);

                    //設定活動資料
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
                        //還有一欄給使用者自填活動主頁網址,視情況再放
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
                    var eventTags = new EventAndTagMapping
                    {
                        EventId = require.EventId,
                        CategoryTagId = require.CategoryId,
                    };


                    DbContext.EventAndTagMappings.Add(eventTags);
                    DbContext.SaveChanges();

                    //TicketTypes: 活動與票卷的關係
                    var ticketDetail = new TicketType
                    {
                        EventId = require.EventId,
                        Name = require.TicketName,
                        StartSaleTime = require.StartSaleTime,
                        EndSaleTime = require.EndSaleTime,
                        Price = require.Prince,
                        CapacityAmount = require.Amount,

                    };
                    DbContext.TicketTypes.Add(ticketDetail);
                    DbContext.SaveChanges();

                    //票區與票的對應
                    var ticketAndSeatAreaMapping = new TicketTypeAndSeatAreaMapping
                    {
                        TicketTypeId = require.TicketTypeId,
                        SeatAreaId = require.SeatAreaId,
                    };
                    DbContext.TicketTypeAndSeatAreaMappings.Add(ticketAndSeatAreaMapping);
                    DbContext.SaveChanges();

                    transcation.Commit();

                    return activity.Id;
                    
                }
                catch (Exception ex) {
                    transcation.Rollback();
                    throw new Exception(ex.Message);
                }
            
        }

        public int UpdateEvent(CreateEventDto require)
        {
            using (var tanscation = DbContext.Database.BeginTransaction())
                try { //同一活動內容
                    var selectedEvent = DbContext.Events
                        .FirstOrDefault(e => e.Id == require.EventId);

                    var contactPersonJson = JsonConvert.SerializeObject(require.ContactPerson);
                    var participantPeopleJson = JsonConvert.SerializeObject(require.ParticipantPeople);

                    //取欄位所需
                    selectedEvent.Name = require.EventName;
                    selectedEvent.OrganizationId = require.OrgId;
                    selectedEvent.StartTime = require.StartTime;
                    selectedEvent.EndTime = require.EndTime;
                    selectedEvent.Type = require.EventStatus;
                    selectedEvent.LocationName = require.LocationName;
                    selectedEvent.LocationAddress = require.EventAddress;
                    selectedEvent.Longitude = require.Longitude;
                    selectedEvent.Latitude = require.Latitude;
                    //還有一欄給使用者自填活動主頁網址,視情況再放
                    selectedEvent.StreamingPlatform = require.StreamingName;
                    selectedEvent.StreamingUrl = require.StreamingUrl;
                    selectedEvent.Capacity = require.Attendance;
                    selectedEvent.ContactPerson = contactPersonJson;
                    selectedEvent.ParticipantPeople = participantPeopleJson;
                    selectedEvent.EventImage = require.EventImage;
                    selectedEvent.Introduction = require.EventIntroduction;
                    selectedEvent.Description = require.EventDescription;
                    selectedEvent.MainOrganizer = require.MainOrganizer;
                    selectedEvent.CoOrganizer = require.CoOrganizer;
                    selectedEvent.IsPrivateEvent = require.IsPrivateEvent;
                    selectedEvent.IsFree = require.IsFree;

                    DbContext.SaveChanges();

                    //Tag: 尋找同一個活動下的標籤
                    var sameEventTag = DbContext.EventAndTagMappings
                        .Where(t => t.EventId == require.EventId).ToList(); ;

                    sameEventTag.ForEach(tag => tag.CategoryTagId = require.CategoryId);
                    DbContext.SaveChanges();

                    //票名,時間,價格,數量
                    //同一活動下的票種內容
                    var sameEventTicketTypes = DbContext.TicketTypes
                        .Where(t => t.EventId == require.EventId).ToList();

                    sameEventTicketTypes.ForEach(
                        tt => {
                            tt.Name = require.TicketName;
                            tt.StartSaleTime = require.StartSaleTime;
                            tt.EndSaleTime = require.EndSaleTime;
                            tt.Price = require.Prince;
                            tt.CapacityAmount = require.Amount;
                        }
                    );
                    DbContext.SaveChanges();

                    //票區與票種:找出每一張票對應的票區,票種                    
                    //同一特定活動(eventId)下的每個票種對應的票區

                    foreach (var ticketType in sameEventTicketTypes)
                    {
                        var sameTicketTypeSeatAreas = DbContext.TicketTypeAndSeatAreaMappings
                            .Where(t => t.TicketTypeId == ticketType.Id).ToList();
                        foreach (var item in sameTicketTypeSeatAreas)
                        {
                            item.SeatAreaId = require.SeatAreaId;
                        }
                    }

                    DbContext.SaveChanges();
                    transcation.Commit();

                    return selectedEvent.Id;
                }
                catch (Exception ex)
                {
                    transcation.Rollback();
                    throw new Exception(ex.Message);
                }
        }

        //===========自動實作==============
        public EventAndTagMapping Add(EventAndTagMapping entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventAndTagMapping> AddRange(IEnumerable<EventAndTagMapping> entities)
        {
            throw new NotImplementedException();
        }

        public EventAndTagMapping Update(EventAndTagMapping entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventAndTagMapping> UpdateRange(IEnumerable<EventAndTagMapping> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(EventAndTagMapping entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<EventAndTagMapping> entities)
        {
            throw new NotImplementedException();
        }

        EventAndTagMapping IRepository<EventAndTagMapping>.GetById<TId>(TId id)
        {
            throw new NotImplementedException();
        }

        public EventAndTagMapping FirstOrDefault(Expression<Func<EventAndTagMapping, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public EventAndTagMapping SingleOrDefault(Expression<Func<EventAndTagMapping, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<EventAndTagMapping, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<EventAndTagMapping> List(Expression<Func<EventAndTagMapping, bool>> expression)
        {
            throw new NotImplementedException();
        }

        List<EventAndTagMapping> IRepository<EventAndTagMapping>.All()
        {
            throw new NotImplementedException();
        }

        public Task<EventAndTagMapping> UpdateAsync(EventAndTagMapping entity)
        {
            throw new NotImplementedException();
        }

        Task<EventAndTagMapping> IRepository<EventAndTagMapping>.GetByIdAsync<TEntityId>(TEntityId id)
        {
            throw new NotImplementedException();
        }

        public CreateEventDto RenderEventData(int eventId)
        {
            throw new NotImplementedException();
        }
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





