using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EventGeneralInfoApiService
    {
        private readonly DatabaseContext DbContext;

        public EventGeneralInfoApiService(DatabaseContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<EventGeneralInfoDto> GetEventGeneralInfoDtoByEventId(int eventId)
        {
            try
            {
                var result = await DbContext.Events
                    .AsNoTracking()
                    .Where(e => e.Id == eventId)
                    .Include(e => e.EventAndTagMappings)
                        .ThenInclude(et => et.CategoryTag)
                    .Select(e => new EventGeneralInfoDto
                    {
                        EventId = eventId,
                        EventName = e.Name,
                        EventStartTime = e.StartTime.ToString("yyyy/MM/dd HH:ss"),
                        EventEndTime = e.EndTime.HasValue ? e.EndTime.Value.ToString("yyyy/MM/dd HH:ss") : null,
                        Organizer = e.MainOrganizer,
                        CoOrganizer = e.CoOrganizer,
                        Capacity = int.Parse(e.Capacity.ToString()),
                        EventType = e.Type == 1 ? "實體活動" : "線上活動",
                        EventBrief = e.Introduction,
                        EventDescription = e.Description,
                        EventImg = e.EventImage,
                        IsPrivate = e.IsPrivateEvent ? "私人" : "公開",
                        CategoryId = e.EventAndTagMappings.FirstOrDefault().CategoryTag.Id,
                        CategoryName = e.EventAndTagMappings.FirstOrDefault().CategoryTag.Name,
                        Longitude = e.Longitude,
                        Latitude = e.Latitude,
                        EventLocationName = e.LocationName,
                        EventLocationAddress = e.LocationAddress,
                    })
                    .FirstOrDefaultAsync();

                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
