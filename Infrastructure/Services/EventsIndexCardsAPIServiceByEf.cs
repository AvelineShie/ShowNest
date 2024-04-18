using ApplicationCore;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ShowNest.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EventsIndexCardsAPIServiceByEf
    {
        private readonly DatabaseContext _databaseContext;

        public EventsIndexCardsAPIServiceByEf(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        static List<string> GetEventStatusAndCssClassName(DateTime input)
        {
            DateTime curr = DateTime.Now;

            if (curr < input)
            {
                return new List<string> { "開賣中", "green-status" };
            }
            else
            {
                return new List<string> { "已結束", "black-status" };
            }
        }

        public async Task<OperationResult> GetCardsByPagesize(QueryParametersDto request)
        {
            try
            {
                int page = request.page;
                int cardsPerPage = request.cardsPerPage;

                // 沒有任何搜尋條件的情況下，樣本是全部的卡片
                if (request.Id == 0 &&
                    string.IsNullOrEmpty(request.inputstring) &&
                    request.MaxPrice == 0 &&
                    request.MinPrice == 0 &&
                    request.StartTime == DateTime.MinValue &&
                    request.EndTime == DateTime.MaxValue &&
                    request.CategoryTag == 0)
                {
                    var totalEventsCount = _databaseContext.Events.Count();
                    var cardsForCurrerntPage = await _databaseContext.EventAndTagMappings
                            .Include(et => et.Event)
                            .Include(et => et.CategoryTag)
                            .OrderByDescending(et => et.CategoryTagId) // 從這邊開始方法相同
                            .ThenBy(et => et.EventId)
                            .Skip((page - 1) * cardsPerPage).Take(cardsPerPage)
                            .Select(et => new EventIndexDto
                            {
                                EventId = et.Event.Id.ToString(),
                                EventName = et.Event.Name,
                                EventImgUrl = et.Event.EventImage,
                                CategoryName = et.CategoryTag.Name,
                                EventTime = et.Event.StartTime,
                                EventStatus = GetEventStatusAndCssClassName(et.Event.StartTime)[0],
                                EventStatusCssClass = GetEventStatusAndCssClassName(et.Event.StartTime)[1],
                                TotalEvents = totalEventsCount
                            })
                            .ToListAsync();

                    return OperationResultHelper.ReturnSuccessData(cardsForCurrerntPage);

                }
                else
                {
                    string inputstring = request.inputstring;
                    decimal minPrice = request.MinPrice;
                    decimal maxPrice = request.MaxPrice;
                    DateTime startTime = request.StartTime;
                    DateTime? endTime = request.EndTime;

                    var query = _databaseContext.Events
                                        .Include(o => o.Organization)
                                        .Include(ea => ea.EventAndTagMappings)
                                            .ThenInclude(ct => ct.CategoryTag)
                                        .Include(t => t.TicketTypes)
                                            .ThenInclude(t => t.Tickets)
                                            .ThenInclude(o => o.Order)
                                            .ThenInclude(u => u.User)
                                        .AsNoTracking();

                    // query string filters
                    if (!string.IsNullOrEmpty(inputstring))
                    {
                        query = query.Where(en => en.Name.Contains(inputstring));
                    }

                    // price filter
                    if (maxPrice <= 3000)
                    {
                        query = query.Where(e => e.TicketTypes.Any(t => t.Price >= minPrice && t.Price <= maxPrice));
                    }

                    // Time range filters
                    else if (endTime.HasValue)
                    {
                        if (startTime == DateTime.Today && endTime.Value == DateTime.Today)
                        {
                            query = query.Where(e => e.StartTime.Date == DateTime.Today && e.EndTime.HasValue && e.EndTime.Value.Date == DateTime.Today);
                        }
                        else if (startTime == DateTime.Today && endTime.Value <= DateTime.Today.AddDays(7))
                        {
                            query = query.Where(e => e.StartTime.Date == DateTime.Today && e.EndTime.HasValue && e.EndTime.Value.Date <= DateTime.Today.AddDays(7));
                        }
                        else if (startTime == DateTime.Today && endTime.Value <= DateTime.Today.AddMonths(1))
                        {
                            query = query.Where(e => e.StartTime.Date == DateTime.Today && e.EndTime.HasValue && e.EndTime.Value.Date <= DateTime.Today.AddMonths(1));
                        }
                        else if (startTime == DateTime.Today && endTime.Value <= DateTime.Today.AddMonths(2))
                        {
                            query = query.Where(e => e.StartTime.Date == DateTime.Today && e.EndTime.HasValue && e.EndTime.Value.Date <= DateTime.Today.AddMonths(2));
                        }
                    }
                    else
                    {
                        // Handle case when endTime is null (no end time specified)
                        // Do nothing or apply a different logic based on your requirements
                    }
                    var results = query.Select(et => new EventIndexDto
                    {
                        EventId =  et.Id.ToString(),
                        EventName = et.Name,
                        EventImgUrl = et.EventImage, 
                        EventTime = et.StartTime, 
                       
                    }).ToList();


                    return OperationResultHelper.ReturnSuccessData(results);
                }



            }
            catch (Exception ex)
            {
                return OperationResultHelper.ReturnErrorMsg(ex.Message);
            }
        }


        //// PJ的方法寫這裡
        //string inputstring = request.inputstring;
        //decimal minPrice = request.MinPrice;
        //decimal maxPrice = request.MaxPrice;
        //DateTime startTime = request.StartTime;
        //DateTime? endTime = request.EndTime;

        //var query = _databaseContext.Events
        //    .Include(o => o.Organization)
        //    .Include(ea => ea.EventAndTagMappings)
        //        .ThenInclude(ct => ct.CategoryTag)
        //    .Include(t => t.TicketTypes)
        //        .ThenInclude(t => t.Tickets)
        //        .ThenInclude(o => o.Order)
        //        .ThenInclude(u => u.User)
        //    .AsNoTracking();

        //if (!string.IsNullOrEmpty(inputstring))
        //{
        //    query = query.Where(en => en.Name.Contains(inputstring));
        //}

        //// Price range filters
        //else if (minPrice == 0) // 免費
        //{
        //    query = query.Where(e => e.TicketTypes.Any(t => t.Price == 0));
        //}
        //else if (maxPrice < 1000)
        //{
        //    query = query.Where(e => e.TicketTypes.Any(t => t.Price > minPrice && t.Price < maxPrice));
        //}
        //else if (maxPrice < 2000)
        //{
        //    query = query.Where(e => e.TicketTypes.Any(t => t.Price > minPrice && t.Price < maxPrice));
        //}
        //else if (maxPrice < 3000)
        //{
        //    query = query.Where(e => e.TicketTypes.Any(t => t.Price > minPrice && t.Price < maxPrice));
        //}
        //else if (minPrice > 3000)
        //{
        //    query = query.Where(e => e.TicketTypes.Any(t => t.Price > minPrice));
        //}

        //// Time range filters
        //else if (endTime.HasValue)
        //{
        //    if (startTime == DateTime.Today && endTime.Value == DateTime.Today)
        //    {
        //        query = query.Where(e => e.StartTime.Date == DateTime.Today && e.EndTime.HasValue && e.EndTime.Value.Date == DateTime.Today);
        //    }
        //    else if (startTime == DateTime.Today && endTime.Value <= DateTime.Today.AddDays(7))
        //    {
        //        query = query.Where(e => e.StartTime.Date == DateTime.Today && e.EndTime.HasValue && e.EndTime.Value.Date <= DateTime.Today.AddDays(7));
        //    }
        //    else if (startTime == DateTime.Today && endTime.Value <= DateTime.Today.AddMonths(1))
        //    {
        //        query = query.Where(e => e.StartTime.Date == DateTime.Today && e.EndTime.HasValue && e.EndTime.Value.Date <= DateTime.Today.AddMonths(1));
        //    }
        //    else if (startTime == DateTime.Today && endTime.Value <= DateTime.Today.AddMonths(2))
        //    {
        //        query = query.Where(e => e.StartTime.Date == DateTime.Today && e.EndTime.HasValue && e.EndTime.Value.Date <= DateTime.Today.AddMonths(2));
        //    }
        //}
        //else
        //{
        //    // Handle case when endTime is null (no end time specified)
        //    // Do nothing or apply a different logic based on your requirements
        //}

        //var results = query.Select(n => n.Id.ToString()).ToList();

    }
}
