using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Azure.Core;
using CloudinaryDotNet.Actions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;
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
                        Type = 0,
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
                        Status = (byte)(request.EventStatus == "online" ? 0 : 1),
                        //CreatedAt = request.CreatedAt,
                        //EditedAt = request.EditedAt
                        ContactPerson = "No People",
                        ParticipantPeople = "No Participant",
                        CreatedAt = DateTime.Now,
                       
                    };

                    //活動標籤: 
                    var eventTags = new EventAndTagMapping
                    {
                        EventId = request.EventId,
                        CategoryTagId = request.CategoryId
                    };

                    DbContext.Events.Add(activity);
                    DbContext.EventAndTagMappings.Add(eventTags);

                    DbContext.SaveChanges();


                    //======================================以下是票卷
                    //TicketTypes: 活動與票卷的關係
                    //把票的資料跟票區ID全部一起foreach然後
                    //List<TicketDetailViewModel> TicketDetail = new List<TicketDetailViewModel>();
                    //foreach (var ticket in TicketDetail)
                    //{
                    //TicketDetailViewModel ticketDetail = new TicketType
                    //{
                    //    EventId = request.EventId,
                    //    Name = request.TicketName,
                    //    StartSaleTime = request.StartSaleTime,
                    //    EndSaleTime = request.EndSaleTime,
                    //    Price = request.Prince,
                    //    CapacityAmount = request.Amount,

                    //};
                    //DbContext.TicketTypes.Add(ticketDetail);
                    //}
                    //DbContext.SaveChanges();

                    //票區與票的對應
                    //var ticketAndSeatAreaMapping = new TicketTypeAndSeatAreaMapping
                    //{
                    //    //TicketTypeId = request.TicketTypeId,
                    //    //SeatAreaId = request.SeatAreaId,
                    //};
                    //DbContext.TicketTypeAndSeatAreaMappings.Add(ticketAndSeatAreaMapping);
                    //DbContext.SaveChanges();

                    transcation.Commit();

                    return activity.Id;

                }
                catch (Exception ex)
                {
                    transcation.Rollback();
                    throw new Exception(ex.Message);
                }

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

        IEnumerable<Event> ICreateEventService.GetOrgEventsByOrgId(int orgId)
        {
            throw new NotImplementedException();
        }

        int ICreateEventService.UpdateEvent(CreateEventDto require)
        {
            throw new NotImplementedException();
        }

        CreateEventDto ICreateEventService.RenderEventData(int eventId)
        {
            throw new NotImplementedException();
        }

        //IEnumerable<ApplicationCore.Entities.Organization> ICreateEventService.GetOrgByUserId(int userId)
        //{
        //    throw new NotImplementedException();
        //}


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





