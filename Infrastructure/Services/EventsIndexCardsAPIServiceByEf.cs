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
                string inputstring = request.inputstring;
                decimal maxPrice = request.MaxPrice;
                decimal minPrice = request.MinPrice;
                DateTime? startTime = request.StartTime;
                DateTime? endTime = request.EndTime;
                int tagId = request.CategoryTag;
                int page = request.page;
                int cardsPerPage = request.cardsPerPage;

                var query = _databaseContext.Events
                                .AsNoTracking()
                                .Include(o => o.Organization)
                                .Include(ea => ea.EventAndTagMappings)
                                    .ThenInclude(ct => ct.CategoryTag)
                                .Include(t => t.TicketTypes)
                                .Where(e => e.StartTime > DateTime.Today);

                // query string filters
                if (!string.IsNullOrEmpty(inputstring))
                {
                    query = query.Where(q => q.Name.Contains(inputstring));
                }

                // category tags filter
                if (tagId != 0)
                {
                    query = query.Where(q => q.EventAndTagMappings.Any(et => et.CategoryTagId == tagId));
                }

                // price filter
                if (!(minPrice == 0 && maxPrice > 3000))
                {
                    query = query.Where(q => q.TicketTypes.Any(t => t.Price >= minPrice && t.Price <= maxPrice));
                }

                // Time range filters
                if (!(startTime == null && endTime == null))
                {
                    query = query.Where(q => q.StartTime <= endTime);
                }

                var totalEventsCount = query.Count();

                var results = await query
                    .OrderBy(q => q.EventAndTagMappings.FirstOrDefault().CategoryTagId)
                    .ThenBy(q => q.Id)
                    .Skip((page - 1) * cardsPerPage).Take(cardsPerPage)
                    .Select(q => new EventIndexDto
                    {
                        EventId = q.Id.ToString(),
                        EventName = q.Name,
                        EventImgUrl = q.EventImage,
                        CategoryName = q.EventAndTagMappings.FirstOrDefault(et => et.CategoryTagId == et.CategoryTag.Id).CategoryTag.Name,
                        EventTime = q.StartTime,
                        EventStatus = GetEventStatusAndCssClassName(q.StartTime)[0],
                        EventStatusCssClass = GetEventStatusAndCssClassName(q.StartTime)[1],
                        TotalEvents = totalEventsCount

                    }).ToListAsync();

                return OperationResultHelper.ReturnSuccessData(results);

            }
            catch (Exception ex)
            {
                return OperationResultHelper.ReturnErrorMsg(ex.Message);
            }
        }
    }
}
