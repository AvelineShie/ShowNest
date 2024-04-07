using ApplicationCore;
using ApplicationCore.DTOs;
using ApplicationCore.Helpers;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task<OperationResult> GetCardsByPagesize(int page, int cardsPerPage)
        {
            try
            {
                var cardsForCurrerntPage = await _databaseContext.EventAndTagMappings
                .Include(et => et.Event)
                .Include(et => et.CategoryTag)
                .OrderBy(et => et.CategoryTagId)
                .ThenBy(et => et.EventId)
                .Skip(page - 1).Take(cardsPerPage)
                .Select(et => new EventIndexDto
                {
                    EventId = et.Event.Id.ToString(),
                    EventName = et.Event.Name,
                    EventImgUrl = et.Event.EventImage,
                    CategoryName = et.CategoryTag.Name,
                    EventTime = et.Event.StartTime,
                })
                .ToListAsync();

                return OperationResultHelper.ReturnSuccessData(cardsForCurrerntPage);
            }
            catch (Exception ex)
            {
                return OperationResultHelper.ReturnErrorMsg(ex.Message);
            }
        }
    }
}
