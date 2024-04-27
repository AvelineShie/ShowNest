using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Azure.Core;
using CloudinaryDotNet.Actions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using static ApplicationCore.DTOs.CreateEventDto;
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

        //找出同一組織的活動
        public IEnumerable<Event> GetOrgEventsByOrgId(int orgId)
        {  
            var events = DbContext.Events
                .Include(e => e.Organization)
                .Where(e => e.OrganizationId == orgId);

            return events;
        }

        //建立新活動 
        public int CreateEvent(CreateEventDto request)
        {

            //會用到不同資料表的部分分開寫
            using (var transcation = DbContext.Database.BeginTransaction())
                try
                {

                    //設定活動資料
                    var activity = new Event
                    {
                        //Id = request.EventId,
                        Name = request.EventName,
                        OrganizationId = request.OrgId,
                        StartTime = request.StartTime,
                        EndTime = request.EndTime,
                        Type = request.EventStatus,
                        //LocationName = request.LocationName,
                        //LocationAddress = request.EventAddress,
                        //Longitude = request.Longitude,
                        //Latitude = request.Latitude,
                        //還有一欄給使用者自填活動主頁網址,視情況再放
                        //StreamingPlatform = request.StreamingName,
                        //StreamingUrl = request.StreamingUrl,
                        Capacity = request.Attendance,
                        EventImage = request.EventImage,
                        Introduction = request.EventIntroduction,
                        Description = request.EventDescription,
                        MainOrganizer = request.MainOrganizer ?? "default",
                        CoOrganizer = request.CoOrganizer,
                        IsPrivateEvent = request.IsPrivateEvent,
                        IsFree = false,
                        //Sort = request.Sort //排序
                        IsDeleted = false,
                        //Status = (byte)(request.EventStatus == "online" ? 0 : 1),
                        Status = request.EventStatus,

                        //EditedAt = request.EditedAt
                        ContactPerson = "No People",
                        ParticipantPeople = "No Participant",
                        CreatedAt = DateTime.Now,
                       
                    };
                    DbContext.Events.Add(activity);

                    //活動標籤: 
                    var eventTags = new EventAndTagMapping
                    {
                        EventId = request.EventId,
                        CategoryTagId = request.CategoryId
                    };

                    DbContext.EventAndTagMappings.Add(eventTags);


                    //======================================以下是票卷
                    List<TicketDetailViewModel> TicketDetail = new List<TicketDetailViewModel>();
                    foreach (var ticket in TicketDetail)
                    {
                        var TicketResult = new TicketType
                        {
                            EventId = ticket.TicketTypeId,
                            Name = ticket.TicketName,
                            StartSaleTime = ticket.StartSaleTime,
                            EndSaleTime = ticket.EndSaleTime,
                            CapacityAmount = ticket.Amount,
                            Price = ticket.Price,
                            CreatedAt = ticket.CreatedAt,

                        };
                        DbContext.TicketTypes.Add(TicketResult);
                    }

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

        //活動渲染
        public CreateEventDto EditEventRender(int eventId)
        {
            var eventData = GetById(eventId);
            var result = new CreateEventDto
            {
                OrgId = eventData.OrganizationId,
                EventId = eventData.Id,
                EventName = eventData.Name,
                StartTime = eventData.StartTime,
                EndTime = eventData.EndTime,
                EventStatus = eventData.Type,
                StreamingName = eventData.StreamingPlatform,
                StreamingUrl = eventData.StreamingUrl,
                LocationName = eventData.LocationName,
                EventAddress = eventData.LocationAddress,
                Longitude = eventData.Longitude,
                Latitude = eventData.Latitude,
                MainOrganizer = eventData.MainOrganizer,
                CoOrganizer = eventData.CoOrganizer,
                Attendance = eventData.Capacity,

                EventIntroduction = eventData.Introduction,
                EventDescription = eventData.Description,
                EventImage = eventData.EventImage,
                IsPrivateEvent = eventData.IsPrivateEvent,

            };

            //tag
            var tagData = DbContext.EventAndTagMappings
                .Where(d => d.EventId == eventId)
                .Select(d => new CreateEventDto{
                    CategoryId = d.CategoryTagId
                });


            //Tickets
            var ticketTypes = DbContext.TicketTypes
                .Where(t => t.EventId == eventId)
                .Select(t => new TicketDetailViewModel
                {
                    TicketTypeId = t.Id,
                    EventId = t.EventId,
                    TicketName = t.Name, 
                    StartSaleTime = t.StartSaleTime,
                    EndSaleTime = t.EndSaleTime,
                    Price = Convert.ToInt32(t.Price),
                    Amount = t.CapacityAmount, 
                })
                .ToList();

            result.TicketDetail = ticketTypes;


            return result;
        }

        //編輯既有活動
        //public int UpdateEvent(CreateEventDto request)
        //{
        //    using (var transcation = DbContext.Database.BeginTransaction())
        //        try
        //        { var targetEvent = DbContext.Events
        //                .FirstOrDefault(e => e.Id == request.EventId);

        //            targetEvent.Name = request.EventName;
        //            targetEvent.Id = request.EventId;
        //            targetEvent.OrganizationId = request.CategoryId;
        //            targetEvent.StartTime = request.StartTime;
        //            targetEvent.EndTime = request.EndTime;
        //            targetEvent.Type = request.EventStatus;
        //            //targetEvent.StreamingPlatform = request.StreamingName;
        //            //targetEvent.StreamingUrl = request.StreamingUrl;
        //            //targetEvent.LocationName = request.LocationName;
        //            //targetEvent.LocationAddress = request.EventAddress;
        //            //targetEvent.Longitude = request.Longitude;
        //            //targetEvent.Latitude = request.Latitude;
        //            targetEvent.Capacity = request.Attendance;
        //            targetEvent.EventImage = request.EventImage;
        //            targetEvent.Introduction = request.EventIntroduction;
        //            targetEvent.Description = request.EventDescription;
        //            targetEvent.MainOrganizer = request.MainOrganizer;
        //            targetEvent.CoOrganizer = request.CoOrganizer;
        //            targetEvent.IsPrivateEvent = request.IsPrivateEvent;
        //            //targetEvent.ContactPerson = request.ContactPerson;
        //            //targetEvent.ParticipantPeople = request.ParticipantPeople;
        //            //targetEvent.IsFree = request.IsFree;
        //            targetEvent.EditedAt = DateTime.Now;

        //            //CategoryTag
        //            var targetTag = DbContext.EventAndTagMappings
        //                 .FirstOrDefault(e => e.EventId == request.EventId);
        //            targetTag.CategoryTagId = request.CategoryId;

        //            //Ticket
        //            List<TicketDetailViewModel> TicketDetail = new List<TicketDetailViewModel>();
        //            var targetTicket = DbContext.TicketTypes
        //                .FirstOrDefault(t => t.EventId == request.EventId);

        //            if (targetTicket != null)
        //            {
        //                foreach (var ticket in TicketDetail)
        //                {
                            
        //                    targetTicket.Id = ticket.TicketTypeId;
        //                    targetTicket.EventId = ticket.EventId;
        //                    targetTicket.Name = ticket.TicketName;
        //                    targetTicket.StartSaleTime = ticket.StartSaleTime;
        //                    targetTicket.EndSaleTime = ticket.EndSaleTime;
        //                    targetTicket.Price = ticket.Price;
        //                    targetTicket.CapacityAmount = ticket.Amount;
        //                    targetTicket.EditedAt = ticket.EditedAt;

        //                }
        //            }

        //            DbContext.SaveChanges();
        //            transcation.Commit();

        //            return targetEvent.Id;

        //        }
        //        catch (Exception ex)
        //        {
        //            transcation.Rollback();
        //            throw new Exception(ex.Message);
        //        }
        //}












        ///==============================自動實作

        IEnumerable<Organization> ICreateEventService.GetOrgByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        CreateEventDto ICreateEventService.RenderEventData(int eventId)
        {
            throw new NotImplementedException();
        }

        EventAndTagMapping IRepository<EventAndTagMapping>.Add(EventAndTagMapping entity)
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

        Task<EventAndTagMapping> IRepository<EventAndTagMapping>.GetByIdAsync<TEntityId>(TEntityId id)
        {
            throw new NotImplementedException();
        }

        int ICreateEventService.UpdateEvent(CreateEventDto require)
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





