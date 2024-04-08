using ApplicationCore;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
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

        //static string ConvertEventTime(DateTime input)
        //{

        //}

        public async Task<OperationResult> GetCardsByPagesize(int page, int cardsPerPage)
        {
            try
            {
                var cardsForCurrerntPage = await _databaseContext.EventAndTagMappings
                .Include(et => et.Event)
                .Include(et => et.CategoryTag)
                .OrderByDescending(et => et.CategoryTagId)
                .ThenBy(et => et.EventId)
                .Skip((page - 1) * 9).Take(cardsPerPage)
                .Select(et => new EventIndexDto
                {
                    EventId = et.Event.Id.ToString(),
                    EventName = et.Event.Name,
                    EventImgUrl = et.Event.EventImage,
                    CategoryName = et.CategoryTag.Name,
                    EventTime = et.Event.StartTime,
                    EventStatus = GetEventStatusAndCssClassName(et.Event.StartTime)[0],
                    EventStatusCssClass = GetEventStatusAndCssClassName(et.Event.StartTime)[1],
                })
                .ToListAsync();

                return OperationResultHelper.ReturnSuccessData(cardsForCurrerntPage);
            }
            catch (Exception ex)
            {
                return OperationResultHelper.ReturnErrorMsg(ex.Message);
            }
        }

        //public async Task<OperationResult> GetCardsByPagesize()
        //{
        //    try
        //    {
        //        var cardsForCurrerntPage = await _databaseContext.EventAndTagMappings
        //        .Include(et => et.Event)
        //        .Include(et => et.CategoryTag)
        //        .OrderBy(et => et.CategoryTagId)
        //        .ThenBy(et => et.EventId)
        //        .Skip(1).Take(9)
        //        .Select(et => new EventIndexDto
        //        {
        //            EventId = et.Event.Id.ToString(),
        //            EventName = et.Event.Name,
        //            EventImgUrl = et.Event.EventImage,
        //            CategoryName = et.CategoryTag.Name,
        //            EventTime = et.Event.StartTime,
        //        })
        //        .ToListAsync();

        //        return OperationResultHelper.ReturnSuccessData(cardsForCurrerntPage);
        //    }
        //    catch (Exception ex)
        //    {
        //        return OperationResultHelper.ReturnErrorMsg(ex.Message);
        //    }
        //}
    }
}
