using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Azure.Core;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using System.Security.Cryptography;
using Organization = ApplicationCore.Entities.Organization;

namespace Infrastructure.Services
{

    public class CreateEventService : EfRepository<Event>, ICreateEventService
    {
        private readonly EfRepository<Event> _repository;
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

        public int CreateEvent(CreateEventDto request)
        {

            //會用到不同資料表的部分分開寫
            using (var transcation = DbContext.Database.BeginTransaction())
                try
                {
                    // 將列表轉 JSON 字串
                    var contactPersonJson = JsonConvert.SerializeObject(request.ContactPerson);
                    var participantPeopleJson = JsonConvert.SerializeObject(request.ParticipantPeople);

                    //設定活動資料
                    var activity = new Event
                    {
                        Id = request.EventId,
                        Name = request.EventName,
                        OrganizationId = request.OrgId,
                        StartTime = request.StartTime,
                        EndTime = request.EndTime,
                        Type = request.EventStatus,
                        LocationName = request.LocationName,
                        LocationAddress = request.EventAddress,
                        Longitude = request.Longitude,
                        Latitude = request.Latitude,
                        //還有一欄給使用者自填活動主頁網址,視情況再放
                        StreamingPlatform = request.StreamingName,
                        StreamingUrl = request.StreamingUrl,
                        Capacity = request.Attendance,
                        ContactPerson = contactPersonJson,
                        ParticipantPeople = participantPeopleJson,
                        EventImage = request.EventImage,
                        Introduction = request.EventIntroduction,
                        Description = request.EventDescription,
                        MainOrganizer = request.MainOrganizer,
                        CoOrganizer = request.CoOrganizer,
                        IsPrivateEvent = request.IsPrivateEvent,
                        IsFree = request.IsFree,
                        Sort = request.Sort, //排序
                        IsDeleted = false,
                        CreatedAt = request.CreatedAt,
                        EditedAt = request.EditedAt
                    };
                    DbContext.Events.Add(activity);
                    DbContext.SaveChanges();

                    //活動標籤
                    var eventTags = new EventAndTagMapping
                    {
                        EventId = request.EventId,
                        CategoryTagId = request.CategoryId,
                    };


                    DbContext.EventAndTagMappings.Add(eventTags);
                    DbContext.SaveChanges();

                    //TicketTypes: 活動與票卷的關係
                    var ticketDetail = new TicketType
                    {
                        EventId = request.EventId,
                        Name = request.TicketName,
                        StartSaleTime = request.StartSaleTime,
                        EndSaleTime = request.EndSaleTime,
                        Price = request.Prince,
                        CapacityAmount = request.Amount,

                    };
                    DbContext.TicketTypes.Add(ticketDetail);
                    DbContext.SaveChanges();

                    //票區與票的對應
                    var ticketAndSeatAreaMapping = new TicketTypeAndSeatAreaMapping
                    {
                        TicketTypeId = request.TicketTypeId,
                        SeatAreaId = request.SeatAreaId,
                    };
                    DbContext.TicketTypeAndSeatAreaMappings.Add(ticketAndSeatAreaMapping);
                    DbContext.SaveChanges();

                    transcation.Commit();

                    return activity.Id;

                }
                catch (Exception ex)
                {
                    transcation.Rollback();
                    throw new Exception(ex.Message);
                }

        }

        public int UpdateEvent(CreateEventDto request)
        {
            using (var tanscation = DbContext.Database.BeginTransaction())
                try
                { //同一活動內容
                    var selectedEvent = DbContext.Events
                        .FirstOrDefault(e => e.Id == request.EventId);

                    var contactPersonJson = JsonConvert.SerializeObject(request.ContactPerson);
                    var participantPeopleJson = JsonConvert.SerializeObject(request.ParticipantPeople);

                    //取欄位所需
                    selectedEvent.Name = request.EventName;
                    selectedEvent.OrganizationId = request.OrgId;
                    selectedEvent.StartTime = request.StartTime;
                    selectedEvent.EndTime = request.EndTime;
                    selectedEvent.Type = request.EventStatus;
                    selectedEvent.LocationName = request.LocationName;
                    selectedEvent.LocationAddress = request.EventAddress;
                    selectedEvent.Longitude = request.Longitude;
                    selectedEvent.Latitude = request.Latitude;
                    //還有一欄給使用者自填活動主頁網址,視情況再放
                    selectedEvent.StreamingPlatform = request.StreamingName;
                    selectedEvent.StreamingUrl = request.StreamingUrl;
                    selectedEvent.Capacity = request.Attendance;
                    selectedEvent.ContactPerson = contactPersonJson;
                    selectedEvent.ParticipantPeople = participantPeopleJson;
                    selectedEvent.EventImage = request.EventImage;
                    selectedEvent.Introduction = request.EventIntroduction;
                    selectedEvent.Description = request.EventDescription;
                    selectedEvent.MainOrganizer = request.MainOrganizer;
                    selectedEvent.CoOrganizer = request.CoOrganizer;
                    selectedEvent.IsPrivateEvent = request.IsPrivateEvent;
                    selectedEvent.IsFree = request.IsFree;

                    DbContext.SaveChanges();

                    //Tag: 尋找同一個活動下的標籤
                    var sameEventTag = DbContext.EventAndTagMappings
                        .Where(t => t.EventId == request.EventId).ToList(); ;

                    sameEventTag.ForEach(tag => tag.CategoryTagId = request.CategoryId);
                    DbContext.SaveChanges();

                    //票名,時間,價格,數量
                    //同一活動下的票種內容
                    var sameEventTicketTypes = DbContext.TicketTypes
                        .Where(t => t.EventId == request.EventId).ToList();

                    sameEventTicketTypes.ForEach(
                        tt =>
                        {
                            tt.Name = request.TicketName;
                            tt.StartSaleTime = request.StartSaleTime;
                            tt.EndSaleTime = request.EndSaleTime;
                            tt.Price = request.Prince;
                            tt.CapacityAmount = request.Amount;
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
                            item.SeatAreaId = request.SeatAreaId;
                        }
                    }

                    DbContext.SaveChanges();
                    tanscation.Commit();

                    return selectedEvent.Id;
                }
                catch (Exception ex)
                {
                    tanscation.Rollback();
                    throw new Exception(ex.Message);
                }
        }

        public CreateEventDto RenderEventData(int eventId)
        {

            var activity = GetById(eventId);
            

            // JSON轉物件
            var contactPersonDeserialize = JsonConvert.DeserializeObject(activity.ContactPerson);
            var participantPeopleDeserialize = JsonConvert.DeserializeObject(activity.ParticipantPeople);

            var result = new CreateEventDto
            {
                EventId = activity.Id,
                EventName = activity.Name,
                OrgId = activity.OrganizationId,
                StartTime = activity.StartTime,
                EndTime = activity.EndTime,
                EventStatus = activity.Status,
                LocationName = activity.LocationName,
                EventAddress = activity.LocationAddress,
                Longitude = activity.Longitude,
                Latitude = activity.Latitude,
                //還有一欄給使用者自填活動主頁網址,視情況再放
                StreamingName = activity.StreamingPlatform,
                StreamingUrl = activity.StreamingUrl,
                Attendance = activity.Capacity,
                //ContactPerson = activity.ContactPerson,
                //ParticipantPeople = participantPeopleJson,

                EventImage = activity.EventImage,
                EventIntroduction = activity.Introduction,
                EventDescription = activity.Description,
                MainOrganizer = activity.MainOrganizer,
                CoOrganizer = activity.CoOrganizer,
                IsPrivateEvent = activity.IsPrivateEvent,
                IsFree = activity.IsFree,

                //=========Ticket==========
                

            };

            DbContext.SaveChanges();
            //transaction.Commit();

            return result;
        }













        //===自動實作====
        public EventAndTagMapping Add(EventAndTagMapping entity)
        {
            throw new NotImplementedException();
        }

        Task<EventAndTagMapping> IRepository<EventAndTagMapping>.GetByIdAsync<TEntityId>(TEntityId id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<EventAndTagMapping> IRepository<EventAndTagMapping>.AddRange(IEnumerable<EventAndTagMapping> entities)
        {
            throw new NotImplementedException();
        }

        EventAndTagMapping IRepository<EventAndTagMapping>.Update(EventAndTagMapping entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<EventAndTagMapping> IRepository<EventAndTagMapping>.UpdateRange(IEnumerable<EventAndTagMapping> entities)
        {
            throw new NotImplementedException();
        }

        void IRepository<EventAndTagMapping>.Delete(EventAndTagMapping entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<EventAndTagMapping>.DeleteRange(IEnumerable<EventAndTagMapping> entities)
        {
            throw new NotImplementedException();
        }

        EventAndTagMapping IRepository<EventAndTagMapping>.GetById<TId>(TId id)
        {
            throw new NotImplementedException();
        }

        EventAndTagMapping IRepository<EventAndTagMapping>.FirstOrDefault(Expression<Func<EventAndTagMapping, bool>> expression)
        {
            throw new NotImplementedException();
        }

        EventAndTagMapping IRepository<EventAndTagMapping>.SingleOrDefault(Expression<Func<EventAndTagMapping, bool>> expression)
        {
            throw new NotImplementedException();
        }

        bool IRepository<EventAndTagMapping>.Any(Expression<Func<EventAndTagMapping, bool>> expression)
        {
            throw new NotImplementedException();
        }

        List<EventAndTagMapping> IRepository<EventAndTagMapping>.List(Expression<Func<EventAndTagMapping, bool>> expression)
        {
            throw new NotImplementedException();
        }

        List<EventAndTagMapping> IRepository<EventAndTagMapping>.All()
        {
            throw new NotImplementedException();
        }

        Task<EventAndTagMapping> IRepository<EventAndTagMapping>.UpdateAsync(EventAndTagMapping entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ApplicationCore.Entities.Organization> ICreateEventService.GetOrgByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}



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





