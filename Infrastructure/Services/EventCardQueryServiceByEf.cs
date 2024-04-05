using ApplicationCore.Entities;
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
            var categoryTagsQueries = await DbContext.CategoryTags
                .Include(c => c.EventAndTagMappings)
                .ThenInclude(et => et.Event)
                .Where(c => c.Id == categoryId)
                .ToListAsync();

            return categoryTagsQueries;
        }

        public async Task<List<CategoryTag>> GetNumbersOfCardsByCategoryId(int cardAmount, int categoryId)
        {
            var categoryTagsQueries = await DbContext.CategoryTags
                .Include(c => c.EventAndTagMappings)
                .ThenInclude(et => et.Event)
                .Where(c => c.Id == categoryId)
                //.Take(cardAmount)
                .ToListAsync();

            return categoryTagsQueries;
        }
    }
}
