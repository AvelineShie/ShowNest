using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EventOverviewService : IEventOverviewService
    {
        private readonly DatabaseContext _dbContext;

        public EventOverviewService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EventsOverviewTicketsDto>> GetEventsOverviewTicketInfo(int eventId)
        {
            var ticketInfo = await _dbContext.TicketTypes
                .Include(tt => tt.Tickets)
                .ThenInclude(t => t.Order)
                .Where(tt => tt.EventId == eventId)
                .Select(tt => new EventsOverviewTicketsDto
                {
                    EventId = tt.EventId,
                    TicketTypeId = tt.Id,
                    TicketTypeName = tt.Name,
                    StartSellingTime = tt.StartSaleTime.ToString("yyyy/MM/dd HH:mm"),
                    EndSellingTime = tt.EndSaleTime.ToString("yyyy/MM/dd HH:mm"),
                    SellingStatus = tt.Tickets
                                    .Where(t => t.TicketTypeId == tt.Id)
                                    .Where(t => t.OrderId != null)
                                    .Count() < tt.CapacityAmount,
                    Price = (int)tt.Price,
                    SoldAmount = tt.Tickets
                                    .Where(t => t.TicketTypeId == tt.Id)
                                    .Where(t => t.OrderId == t.Order.Id)
                                    .Select(t => t.Order)
                                    .Where(o => o.Status == 0 || o.Status == 1)
                                    .Count(),
                    PaidAmout = tt.Tickets
                                    .Where(t => t.TicketTypeId == tt.Id)
                                    .Where(t => t.OrderId == t.Order.Id)
                                    .Select(t => t.Order)
                                    .Count(o => o.Status == 1),
                    WaitingToPayAmout = tt.Tickets
                                    .Where(t => t.TicketTypeId == tt.Id)
                                    .Where(t => t.OrderId == t.Order.Id)
                                    .Select(t => t.Order)
                                    .Count(o => o.Status == 0),
                    RemainAmout = (int)tt.CapacityAmount - tt.Tickets
                                    .Where(t => t.TicketTypeId == tt.Id)
                                    .Where(t => t.OrderId == t.Order.Id)
                                    .Select (t => t.Order)
                                    .Where(o => o.Status == 0 || o.Status == 1)
                                    .Count(),
                    PriceOfPaidAmout = tt.Tickets
                                    .Where(t => t.TicketTypeId == tt.Id)
                                    .Where(t => t.OrderId == t.Order.Id)
                                    .Select(t => t.Order)
                                    .Where(o => o.Status == 1)
                                    .Count() * (int)tt.Price,
                })
                .ToListAsync();

            return ticketInfo;
        }
    }
}
