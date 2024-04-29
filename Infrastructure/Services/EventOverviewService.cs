using ApplicationCore.DTOs;
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
    public class EventOverviewService : IEventOverviewService
    {
        private readonly DatabaseContext _dbContext;

        public EventOverviewService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EventsOverviewDto> GetEventOverviewDto(int eventId)
        {
            var generalInfo = _dbContext.Events
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == eventId);

            var tickets = await GetEventsOverviewTicketsInfo(eventId) ?? new List<EventsOverviewTicketsDto>();

            int allSoldTicketsCount = 0;
            int allRemainedTicketsCount = 0;
            int allTicketsAmount = 0;

            var orders = await GetEventsOverviewOrdersInfo(eventId);

            foreach (var ticket in tickets)
            {
                allSoldTicketsCount += ticket.SoldAmount;
                allRemainedTicketsCount += ticket.RemainAmount;
            }

            allTicketsAmount += (allSoldTicketsCount + allRemainedTicketsCount);

            var result = new EventsOverviewDto
            {
                EventId = generalInfo.Id,
                EventName = generalInfo.Name,
                AllSoldTicketsCount = allSoldTicketsCount,
                AllRemainedTicketsCount = allRemainedTicketsCount,
                AllTicketsAmount = allTicketsAmount,
                EventTime = generalInfo.StartTime.ToString("yyyy/MM/dd HH:ss"),
                EventPlace = $"{generalInfo.LocationName} / {generalInfo.LocationAddress}",
                Tickets = tickets,
                Orders = orders
            };

            return result;
        }

        public async Task<List<EventsOverviewTicketsDto>> GetEventsOverviewTicketsInfo(int eventId)
        {
            try
            {
                var ticketsInfo = await _dbContext.TicketTypes
                .AsNoTracking()
                .Include(tt => tt.Tickets)
                .ThenInclude(t => t.Order)
                .Where(tt => tt.EventId == eventId)
                .Select(tt => new EventsOverviewTicketsDto
                {
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
                    PaidAmount = tt.Tickets
                                    .Where(t => t.TicketTypeId == tt.Id)
                                    .Where(t => t.OrderId == t.Order.Id)
                                    .Select(t => t.Order)
                                    .Count(o => o.Status == 1),
                    WaitingToPayAmount = tt.Tickets
                                    .Where(t => t.TicketTypeId == tt.Id)
                                    .Where(t => t.OrderId == t.Order.Id)
                                    .Select(t => t.Order)
                                    .Count(o => o.Status == 0),
                    RemainAmount = (int)tt.CapacityAmount - tt.Tickets
                                    .Where(t => t.TicketTypeId == tt.Id)
                                    .Where(t => t.OrderId == t.Order.Id)
                                    .Select(t => t.Order)
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

                return ticketsInfo;
            }
            catch
            {
                return null;
            }
            
        }

        public async Task<List<EventsOverviewOrdersDto>> GetEventsOverviewOrdersInfo(int eventId)
        {
            try
            {
                var ordersInfo = await _dbContext.Orders
                        .AsNoTracking()
                        .Include(o => o.Event)
                        .Where(o => o.EventId == eventId && o.Tickets.Any())
                        .Include(o => o.Tickets)
                            .ThenInclude(t => t.TicketType)
                        .Include(o => o.User)
                            .ThenInclude(u => u.LogInInfo)
                        .Select(o => new EventsOverviewOrdersDto
                        {
                            OrderId = o.Id,
                            UserName = o.User.Nickname,
                            UserEmail = o.User.LogInInfo.Email,
                            UserPhone = o.User.Mobile,
                            OrderedTicketAmount = o.Tickets.Count,
                            OrderedTicketTotalPrice = (int)o.Tickets.Sum(t => t.TicketType.Price),
                        })
                        .ToListAsync();

                return ordersInfo;
            }
            catch
            {
                return null;
            }
            
        }

    }
}
