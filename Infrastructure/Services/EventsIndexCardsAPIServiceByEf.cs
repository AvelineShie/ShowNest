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

				string inputstring = request.inputstring;
				decimal minPrice = request.MinPrice;
				decimal maxPrice = request.MaxPrice;
				DateTime? startTime = request.StartTime;
				DateTime? endTime = request.EndTime;

				var query = _databaseContext.Events
									.Include(o => o.Organization)
									.Include(ea => ea.EventAndTagMappings)
										.ThenInclude(ct => ct.CategoryTag)
									.Include(t => t.TicketTypes)
									.Where(e => e.StartTime > DateTime.Today)
									.AsNoTracking();



				// query string filters
				if (!string.IsNullOrEmpty(inputstring))
				{
					query = query.Where(en => en.Name.Contains(inputstring));
				}

				// price filter
				if (!(minPrice == 0 && maxPrice > 3000))
				{
					query = query.Where(e => e.TicketTypes.Any(t => t.Price >= minPrice && t.Price <= maxPrice));
				}

				// Time range filters
				if (!(startTime == null && endTime == null))
				{
					query = query.Where(e => e.StartTime <= endTime);
				}

				var totalEventsCount = query.Count();

				var results = query
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

					}).ToList();

				return OperationResultHelper.ReturnSuccessData(results);

			}
			catch (Exception ex)
			{
				return OperationResultHelper.ReturnErrorMsg(ex.Message);
			}
		}
	}
}
