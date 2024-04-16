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
                                TotalEvents = totalEventsCount
                            })
                            .ToListAsync();

                    return OperationResultHelper.ReturnSuccessData(cardsForCurrerntPage);

                }
                else
                {
                    // PJ的方法寫這裡
                    return null;
                }


            }
            catch (Exception ex)
            {
                return OperationResultHelper.ReturnErrorMsg(ex.Message);
            }
        }

        //public async Task<OperationResult> GetCardsByPagesize(int page, int cardsPerPage)
        //{
        //    try
        //    {
        //        var cardsForCurrerntPage = await _databaseContext.EventAndTagMappings
        //        .Include(et => et.Event)
        //        .Include(et => et.CategoryTag)
        //        .OrderByDescending(et => et.CategoryTagId)
        //        .ThenBy(et => et.EventId)
        //        .Skip((page - 1) * 9).Take(cardsPerPage)
        //        .Select(et => new EventIndexDto
        //        {
        //            EventId = et.Event.Id.ToString(),
        //            EventName = et.Event.Name,
        //            EventImgUrl = et.Event.EventImage,
        //            CategoryName = et.CategoryTag.Name,
        //            EventTime = et.Event.StartTime,
        //            EventStatus = GetEventStatusAndCssClassName(et.Event.StartTime)[0],
        //            EventStatusCssClass = GetEventStatusAndCssClassName(et.Event.StartTime)[1],
        //            TotalEvents = GetTotalEventsCount()
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
