using ApplicationCore.Entities;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EventCardQueryServiceByEf : IEventCardQueryService
    {
        private readonly DatabaseContext DbContext;

        public EventCardQueryServiceByEf(DatabaseContext context)
        {
            DbContext = context;
        }

        public async Task<List<CategoryTag>> GetAllCardsByCategoryId(int categoryId)
        {
            // 因為輸入的是categoryId，所以從CategoryTags出發，關連EventAndTagMappings，再關連Event (順序很重要)
            var categoryTagsQuery = await DbContext.CategoryTags
                .Where(c => c.Id == categoryId)
                .Include(c => c.EventAndTagMappings)
                .ThenInclude(et => et.Event)
                .ToListAsync();

            return categoryTagsQuery;
        }

        public async Task<List<CategoryTag>> GetNumbersOfCardsByCategoryId(int cardAmount, int categoryId)
        {
            var categoryTagsQuery = await DbContext.CategoryTags
                .AsNoTracking()
                .Where(c => c.Id == categoryId)
                .Include(c => c.EventAndTagMappings)
                .ThenInclude(et => et.Event)
                .Where(c => c.EventAndTagMappings.Any(et => et.Event.StartTime > DateTime.Today))
                .Take(cardAmount)
                .ToListAsync();

            return categoryTagsQuery;
        }

        //一次拿取全部卡片，太耗效能，這個方法目前不用
        public async Task<List<EventIndexDto>> GetEventIndexCards()
        {
            //var query = await DbContext.EventAndTagMappings
            //    .Include(et => et.Event)
            //    .Include(et => et.CategoryTag)
            //    .OrderBy(et => et.CategoryTagId)
            //    .ThenBy(et => et.EventId)
            //    .Select(et => new EventIndexDto
            //    {
            //        EventId = et.Event.Id.ToString(),
            //        EventName = et.Event.Name,
            //        EventImgUrl = et.Event.EventImage,
            //        CategoryName = et.CategoryTag.Name,
            //        EventTime = et.Event.StartTime,
            //    })
            //    .ToListAsync();

            //return query;
            return new List<EventIndexDto>();
        }
    }
}
